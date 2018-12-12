using CYBInfrastructure.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CYBInfrastructure.Web.Models;
using CYBInfracstructure.DataStructure.Entities;
using System.Net;   
using CYBInfrastructure.Core.Interfaces;
using System.Data.Entity.Infrastructure;
using Rotativa.MVC;
using OfficeOpenXml;

namespace CYBInfrastructure.Web.Controllers
{
    //[AllowAnonymous]
    //[Authorize(Roles = "RoleAdmin")]

    public class LocationController : Controller
    {
        public LocationController()
        {
                
        }
        private readonly ILocationManager _locationmanager;
        public LocationController( ILocationManager _locationmanager)
        {
            this._locationmanager = _locationmanager;
        }
        // GET: Location
      
        public ActionResult Index()
        {
            try
            {
                var locations = _locationmanager.GetAll();
                var llvm = new LocationListViewModel
                {
                    Locations = locations
                };
                //ViewData["Username"] = User.Identity.Name;
                return View(llvm);
            }
            catch (Exception ex)
            {
               
               //Log exception
              return View(ex.Message, "Error");

            }        

        }
        [HttpGet]
        // [Authorize]
        //[Authorize(Roles = "RoleAdmin, UserRole")]
        [Authorize(Roles = "RoleAdmin")]
        public ActionResult Create()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult Create(LocationViewModel location)
        {
            if(ModelState.IsValid)
            {
                var dept = new Location
                {
                    Id = location.Id,
                    LocationName = location.LocationName,
                    Date = location.Date,
                    Description = location.Description
                };
                _locationmanager.Add(dept);
                _locationmanager.GetAll().ToList();
                _locationmanager.SaveChanges();
               TempData["Success"] = "Added Successfully!";

                //return Json(new { success = true, messsage = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                //TempData["message"] = string.Format("{0} has been saved.", location);
                return RedirectToAction("Index");
            }
            else
            {
                return View(location);
            }
           

            //return View();         
        }
        //[Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = _locationmanager.SelectList(x => x.Id == id).FirstOrDefault();
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var locationToUpdate = _locationmanager.SelectList(x => x.Id == id).FirstOrDefault();
            if (TryUpdateModel(locationToUpdate, "",
               new string[] { "LocationName", "Description" ,"Date"}))
            {
                try
                {
                    _locationmanager.Edit(locationToUpdate);
                    _locationmanager.SaveChanges();

                    TempData["Success"] = "Edited Successfully!";

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }

            return View(locationToUpdate);
        }
        //[Authorize]
        [HttpGet]
        public ActionResult Delete(int? id)
        {          
            Location location = _locationmanager.Find(x => x.Id == id).FirstOrDefault();
            return View(location);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Location location = _locationmanager.Find(x => x.Id == id).FirstOrDefault();

            _locationmanager.Remove(location);
            _locationmanager.SaveChanges();
            TempData["Success"] = "Deleted Successfully!";

            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            Location location = _locationmanager.Find(x => x.Id == id).FirstOrDefault();
            return View(location);
        }

        public ActionResult Export()
        {

            var list = _locationmanager.GetAll().ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Id";
            ws.Cells["B1"].Value = "Location Name";
            ws.Cells["C1"].Value = "Description";
            ws.Cells["D1"].Value = "Date";



            int rowStart = 2;
            foreach (var item in list)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.Id;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.LocationName;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Description;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.Date;

                rowStart++;
            }

            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();

            return RedirectToAction("Index");
        }

        public ActionResult Pdf()
        {
            var file = _locationmanager.GetAll().ToList();
           

            var  viewAsPdf = new ViewAsPdf("Index", file)

            {
                FileName = "LocationProject.pdf"
            };

            return viewAsPdf;
        }

    }
}
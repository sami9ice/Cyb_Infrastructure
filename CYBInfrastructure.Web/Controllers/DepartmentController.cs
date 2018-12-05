using CYBInfrastructure.Core.Managers;
using CYBInfrastructure.Web.Models;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CYBInfrastructure.Core.Interfaces;
using CYBInfracstructure.DataStructure.Entities;
//using CYBInfracstructure.DataStructure.Migrations;
using Vereyon.Web;
using OfficeOpenXml;
using Rotativa.MVC;

namespace CYBInfrastructure.Web.Controllers
{
    public class DepartmentController : Controller
    {
        public DepartmentController()
        {

        }
       private readonly  IDepartmentManager _department;
        private readonly ILocationManager locationManager;
        public DepartmentController(IDepartmentManager _department, ILocationManager locationManager)
        {
            this._department = _department;
            this.locationManager = locationManager;
        }
        // GET: Department
        public ActionResult Index()
        {
            
            try
            {
                var Departments = _department.GetAll();
                var dlvm = new DepartmentListViewModel
                {
                    departments = Departments
                };
                return View(dlvm);
            }
            catch (Exception ex)
            {

                //Log exception
                return View(ex.Message, "Error");

            }

        }


        [Authorize]

        [HttpGet]
        public ActionResult Create()
        {
            var locations = locationManager.GetAll().ToList();
           
            DepartmentViewModel department = new DepartmentViewModel
            {
                Locations = locations
            };

            return View(department);
        }

        [HttpPost]
        public ActionResult Create(DepartmentViewModel dvm)
        {
            if(ModelState.IsValid)
            {
                var department = new CYBInfracstructure.DataStructure.Entities.Department
                {
                    DepartmentName = dvm.DepartmentName,
                    IsActive = dvm.IsActive,
                    LocationId = dvm.LocationId,
                    Date = dvm.Date

                };

                _department.Add(department);
                _department.SaveChanges();
                //return Json(new { success = true, messsage = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                //FlashMessage.Confirmation("You have been logged in as: {0}");

                TempData["Success"] = "Added Successfully!";


                return RedirectToAction("Index");
            }
            var locations = locationManager.GetAll().ToList();

            DepartmentViewModel departmentModel = new DepartmentViewModel
            {
                Locations = locations
            };

            return View(departmentModel);


        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)       
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CYBInfracstructure.DataStructure.Entities.Department department = _department.Find(x => x.Id == id).FirstOrDefault();
            ViewBag.locations = locationManager.GetAll();
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        [HttpPost]
        public ActionResult Edit(DepartmentViewModel dvm)
        {
            var dept = new CYBInfracstructure.DataStructure.Entities.Department
            {
                DepartmentName = dvm.DepartmentName ,
                Id = dvm.Id,
                LocationId = dvm.LocationId,
                IsActive = dvm.IsActive,
                Date = dvm.Date

            };

            if (TryUpdateModel(dept))
            {
                _department.Edit(dept);             
                _department.SaveChanges();
                TempData["Success"] = "Edited Successfully!";
                //TempData["Message"] = "Client Details Edited Successfully";
               
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            CYBInfracstructure.DataStructure.Entities.Department department = _department.Find(x => x.Id == id).FirstOrDefault();
            return View(department);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            CYBInfracstructure.DataStructure.Entities.Department department = _department.Find(x => x.Id == id).FirstOrDefault();
            _department.Remove(department);
            _department.SaveChanges();
            TempData["Success"] = "Deleted Successfully!";

            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            CYBInfracstructure.DataStructure.Entities.Department department = _department.Find(x => x.Id == id).FirstOrDefault();
            return View(department);
        }


        public ActionResult Export()
        {

            var list = _department.GetAll().ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Id";
            ws.Cells["B1"].Value = "Depoartment Name";
            ws.Cells["C1"].Value = "Is Active";
            ws.Cells["D1"].Value = "Location Name";
            ws.Cells["E1"].Value = "Date";


            int rowStart = 2;
            foreach (var item in list)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.Id;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.DepartmentName;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.IsActive;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.Location.LocationName;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.Date;

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
            var list = _department.GetAll().ToList();

            var viewAsPdf = new ViewAsPdf("Index", list)

            {
                FileName = "DepartmentProject.pdf"
            };

            return viewAsPdf;
        }


    }




}
using CYBInfrastructure.Core.Interfaces;
using CYBInfrastructure.Web.Models;
using System;
using System.Collections.Generic;
using CYBInfracstructure.DataStructure.Entities;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using CYBInfracstructure.DataStructure.Migrations;
using CYBInfrastructure.Core.Managers;
using System.Net;
using OfficeOpenXml;
using Rotativa.MVC;

namespace CYBInfrastructure.Web.Controllers
{
    //[AllowAnonymous]

    public class ServiceController : Controller
    {
        public ServiceController()
        {

        }
        private readonly IServiceManager _service;
        private readonly IInventoryManager _InventoryManager;
        public ServiceController(IServiceManager _service, IInventoryManager _InventoryManager)
        {
            this._service = _service;
            this._InventoryManager = _InventoryManager;
        }



        public ActionResult Index()
        {

            try
            {
                var services = _service.GetAll();
                var slvm = new ServiceListViewModel
                {
                    Services = services

                };
                return View(slvm);
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
            var Invent = _InventoryManager.GetAll().ToList();

            ServiceViewModel service = new ServiceViewModel
            {
                Inventories = Invent
            };

            return View(service);
        }

        [HttpPost]
        public ActionResult Create(ServiceViewModel svm)
        {
            
            if (ModelState.IsValid)
            {
                var Invent = _InventoryManager.Find(r => r.ServerName == svm.Inventory).FirstOrDefault();

                var service = new Services
                {
                    Name = svm.Name,
                    Description = svm.Description,
                    IsActive = svm.IsActive,
                    Port = svm.Port,
                    URL = svm.URL,
                    InventoryId = svm.InventoryId,
                    Inventories= svm.Inventories,
                    Date = svm.Date
                };

                _service.Add(service);
                _service.SaveChanges();
                TempData["Success"] = "Added Successfully!";

                return RedirectToAction("Index");
            }
            else
            {
                var Invent = _InventoryManager.GetAll().ToList();
                ViewBag.Inventories = new SelectList(Invent);
                return View(svm);
            }

        }
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = _service.Find(x => x.Id == id).FirstOrDefault();
            ViewBag.Invent = _InventoryManager.GetAll();
            if (services == null)
            {
                return HttpNotFound();
            }
            return View(services);
        }
        [HttpPost]
        public ActionResult Edit(ServiceViewModel svm)
        {
            var services = new Services
            {
                Name = svm.Name,
                Id = svm.Id,
                Description = svm.Description,
                IsActive = svm.IsActive,
                Port = svm.Port,
                URL = svm.URL,
                InventoryId = svm.InventoryId,
                Date = svm.Date
            };

            if (TryUpdateModel(services))
            {
                _service.Edit(services);
                _service.SaveChanges();
                TempData["Success"] = "Edited Successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Services services = _service.Find(x => x.Id == id).FirstOrDefault();
            return View(services);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Services services = _service.Find(x => x.Id == id).FirstOrDefault();
            _service.Remove(services);
            _service.SaveChanges();
            TempData["Success"] = "Deleted Successfully!";
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            Services services = _service.Find(x => x.Id == id).FirstOrDefault();
            return View(services);
        }
        public ActionResult Export()
        {

            var list = _service.GetAll().ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Id";
            ws.Cells["B1"].Value = "Name";
            ws.Cells["C1"].Value = "Description";
            ws.Cells["D1"].Value = "Is Active";
            ws.Cells["E1"].Value = "Server Name";
            ws.Cells["F1"].Value = "Date ";



            int rowStart = 2;
            foreach (var item in list)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.Id;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Name;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Description;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.IsActive;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.Inventory.ServerName;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.Date;

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
            var list = _service.GetAll().ToList();

            var viewAsPdf = new ViewAsPdf("Index", list)

            {
                FileName = "ServiceProject.pdf"
            };

            return viewAsPdf;
        }
    }
}
using CYBInfracstructure.DataStructure.Entities;
using CYBInfrastructure.Core.Interfaces;
using CYBInfrastructure.Core.Managers;
using CYBInfrastructure.Web.Models;
using OfficeOpenXml;
using Rotativa.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CYBInfrastructure.Web.Controllers
{

    //[Authorize]
    public class UnitController : Controller
    {
        public UnitController()
        {

        }
        private readonly IUnitManager _unit;
        private readonly IDepartmentManager departmentManager;
        private readonly ILocationManager locationManager;



        public UnitController(IUnitManager _unit,IDepartmentManager departmentManager, ILocationManager locationManager)
        {
           this._unit = _unit;
            this.departmentManager = departmentManager;
            this.locationManager = locationManager;

        }
        // GET: Department
        public ActionResult Index()
        {

           
            try
            {
                var _units = _unit.GetAll();
                var ulvm = new UnitListViewModel
                {
                    Units = _units
                };
                return View(ulvm);
            }
            catch (Exception ex)
            {

                //Log exception
                return View(ex.Message, "Error");

            }

        }

        //[Authorize]

        [HttpGet]
        public ActionResult Create()
        {
            var department = departmentManager.GetAll().ToList();
            var location = locationManager.GetAll().ToList();



            UnitViewModel unit = new UnitViewModel
            {
                Departments = department,
                Locations = location
            };

            return View(unit);
        }

        [HttpPost]
        public ActionResult Create(UnitViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                var unit = new Unit
                {
                    UnitName = uvm.UnitName,
                    //Departments = uvm.Departments,
                    DepartmentId = uvm.DepartmentId,
                   LocationId = uvm.LocationId,
                   Date = uvm.Date
                   //Locations = uvm.Locations
                };

                _unit.Add(unit);
                _unit.SaveChanges();
                TempData["Success"] = "Added Successfully!";

                return RedirectToAction("Index");
            }


            var department = departmentManager.GetAll().ToList();
            var location = locationManager.GetAll().ToList();



            UnitViewModel unitModel = new UnitViewModel
            {
                Departments = department,
                Locations = location
            };

            return View(unitModel);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = _unit.Find(x => x.Id == id).FirstOrDefault();
            ViewBag.departments = departmentManager.GetAll();
            ViewBag.locations = locationManager.GetAll();
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }
        [HttpPost]
        public ActionResult Edit(UnitViewModel uvm)
        {
            var unit = new Unit
            {
                UnitName = uvm.UnitName,
                Id = uvm.Id,
               
                LocationId = uvm.LocationId,
                //Location = uvm.Location,
                DepartmentId = uvm.DepartmentId,
                Date = uvm.Date
                //Department = uvm.Department
            };

            if (TryUpdateModel(unit))
            {
                _unit.Edit(unit);
                _unit.SaveChanges();
                TempData["Success"] = "Edited Successfully!";           
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Unit unit = _unit.Find(x => x.Id == id).FirstOrDefault();
            return View(unit);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Unit unit = _unit.Find(x => x.Id == id).FirstOrDefault();
            _unit.Remove(unit);
            _unit.SaveChanges();
            TempData["Success"] = "Deleted Successfully!";
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            Unit unit = _unit.Find(x => x.Id == id).FirstOrDefault();
            return View(unit);
        }

        public ActionResult Export()
        {

            var list = _unit.GetAll().ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Id";
            ws.Cells["B1"].Value = "Location Name";
            ws.Cells["C1"].Value = "Department Name";
            ws.Cells["D1"].Value = "Location Name";
            ws.Cells["E1"].Value = "Date";


            int rowStart = 2;
            foreach (var item in list)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.Id;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.UnitName;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Department.DepartmentName;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.Department.Location.LocationName;
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
            var list = _unit.GetAll().ToList();

            var viewAsPdf = new ViewAsPdf("Index", list)

            {
                FileName = "UnitProject.pdf"
            };

            return viewAsPdf;
        }
    }

}
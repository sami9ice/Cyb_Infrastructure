using CYBInfracstructure.DataStructure;
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
    //[AllowAnonymous]

    //[AuthorizeUserAccessLevel(UserRole = "SuperAdmin,Admin,UserRole")]

    [Filters.AuthorizeAdmin]

    public class VirtualMachineController : Controller
    {
        public VirtualMachineController()
        {

        }

        private readonly IInventoryManager _InventoryManager;
        private readonly ILocationManager _locationManager;
        private readonly IUnitManager _unitManager;
        private readonly IHostManager _hostManager;

        public VirtualMachineController(IUnitManager _unitManager, IInventoryManager _InventoryManager, ILocationManager _locationManager,IHostManager _hostManager)
        {
            this._InventoryManager = _InventoryManager;
            this._unitManager = _unitManager;
            this._locationManager = _locationManager;
            this._hostManager = _hostManager;

        }
        public ActionResult Index()
        {


            try
            {
                var _invent = _InventoryManager.GetAll();
                var Ilvm = new InventoryListViewModel
                {
                    Inventories = _invent
                };
                return View(Ilvm);
            }
            catch (Exception ex)
            {

                //Log exception
                return View(ex.ToString());

            }

        }
        [HttpGet]
        public ActionResult Create()
        {
            var location = _locationManager.GetAll().ToList();
            var unit = _unitManager.GetAll().ToList();
            var host = _hostManager.GetAll().ToList();

            InventoryViewModel inventory = new InventoryViewModel
            {
                Locations = location,
                Units = unit,
                Hosts = host

            };
            return View(inventory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ServerName,HostName,Date,PrimaryIP,SecondaryIP,Description,VLAN,Gateway,LocationId,UnitId,HostId,Environment,")]InventoryViewModel ivm)
        {
            CYBInfrastrctureContext db = new CYBInfrastrctureContext();

            bool Create = db.Inventories.Any(x => x.ServerName == ivm.ServerName && x.Id != ivm.Id);
            if (Create == true)
             {
                //TempData["Success"] = "Server already exists, Try another one";

                //ViewBag.message= "Server already exists, Try another one";
                ModelState.AddModelError("SeverName", "Server already exists, Try another one");
             }


            if (ModelState.IsValid)
               
            {
                var invent = new Inventory
                {
                    Id = ivm.Id,
                    ServerName = ivm.ServerName,
                    HostName = ivm.HostName,
                    PrimaryIP = ivm.PrimaryIP,
                    SecondaryIP = ivm.SecondaryIP,
                    Description = ivm.Description,
                    VLAN = ivm.VLAN,
                    Gateway=ivm.Gateway,
                    LocationId = ivm.LocationId,
                    UnitId = ivm.UnitId,
                    HostId = ivm.HostId,
                    Environment = ivm.Environments,
                    Date = ivm.Date

                    //ServerType=ivm.ServerTypes,

                };
                _InventoryManager.Add(invent);
                _InventoryManager.SaveChanges();
                TempData["Success"] = "Added Successfully!";

                return RedirectToAction("Index");
            }
            //var location = _locationManager.GetAll().ToList();
            //var unit = _unitManager.GetAll().ToList();
            //InventoryViewModel inventorymodel = new InventoryViewModel
            //{
            //    Locations = location,
            //    Units = unit

            //};
            return View(ivm);

        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = _InventoryManager.Find(x => x.Id == Id).FirstOrDefault();
            ViewBag.locations = _locationManager.GetAll();
            ViewBag.units = _unitManager.GetAll();
            ViewBag.hosts = _hostManager.GetAll();
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        [HttpPost]
        public ActionResult Edit(InventoryViewModel ivm)
        {
            try
            {
                var inventory = new Inventory
                {
                    Id = ivm.Id,
                    ServerName = ivm.ServerName,
                    HostName = ivm.HostName,
                    PrimaryIP = ivm.PrimaryIP,
                    SecondaryIP = ivm.SecondaryIP,
                    Description = ivm.Description,
                    VLAN = ivm.VLAN,
                    Gateway = ivm.Gateway,
                    LocationId = ivm.LocationId,
                    UnitId = ivm.UnitId,
                    Environment = ivm.Environments,
                    HostId = ivm.HostId,
                    Date = ivm.Date


                    //ServerType = ivm.ServerTypes,

                };
                if (TryUpdateModel(inventory))
                {
                    _InventoryManager.Edit(inventory);
                    _InventoryManager.SaveChanges();
                    TempData["Success"] = "Edited Successfully!";

                    return RedirectToAction("Index");
                }
            }
            catch
            {

            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            Inventory inventory = _InventoryManager.Find(x => x.Id == Id).FirstOrDefault();
            return View(inventory);
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Inventory inventory = _InventoryManager.Find(x => x.Id == Id).FirstOrDefault();

            _InventoryManager.Remove(inventory);
            _InventoryManager.SaveChanges();
            TempData["Success"] = "Deleted Successfully!";
            return RedirectToAction("Index");

        }
        public ActionResult Details(int? Id)
        {
            Inventory inventory = _InventoryManager.Find(x => x.Id == Id).FirstOrDefault();
            return View(inventory);
        }

        public ActionResult Export()
        {

            var list = _InventoryManager.GetAll().ToList();
            var host = _hostManager.GetAll().ToList();


            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Id";
            ws.Cells["B1"].Value = "Server Name";
            ws.Cells["C1"].Value = "Date";
            ws.Cells["D1"].Value = "Ip Address";
            ws.Cells["E1"].Value = "Public Id";
            ws.Cells["F1"].Value = "Description";
            ws.Cells["G1"].Value = "Location Name";
            ws.Cells["H1"].Value = "Unit Name";
            ws.Cells["I1"].Value = "VLAN";
            ws.Cells["J1"].Value = "Gateway";
            ws.Cells["K1"].Value = "Environment";
            ws.Cells["L1"].Value = "Host Name";
            ws.Cells["M1"].Value = "Host IP Address";





            int rowStart = 2;
            foreach (var item in list ) 
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.Id;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.ServerName;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Date;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.PrimaryIP;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.SecondaryIP;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.Description;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.Location.LocationName;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.Unit.UnitName;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.VLAN;
                ws.Cells[string.Format("J{0}", rowStart)].Value = item.Gateway;
                ws.Cells[string.Format("K{0}", rowStart)].Value = item.Environment;
                ws.Cells[string.Format("L{0}", rowStart)].Value = item.Host.HostName;
                ws.Cells[string.Format("M{0}", rowStart)].Value = item.Host.IpAddress;




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
            var list = _InventoryManager.GetAll().ToList();

            var viewAsPdf = new ViewAsPdf("Index", list)

            {
                FileName = "InventoryProject.pdf"
            };

            return viewAsPdf;
        }
    }
}
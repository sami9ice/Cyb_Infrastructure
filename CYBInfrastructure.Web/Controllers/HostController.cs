using CYBInfracstructure.DataStructure;
using CYBInfracstructure.DataStructure.Entities;
using CYBInfrastructure.Core.Interfaces;
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
    public class HostController : Controller
    {


        public HostController()
        {

        }
        private readonly IHostManager _host;
        private readonly IInventoryManager _InventoryManager;
        public HostController(IHostManager _host, IInventoryManager _InventoryManager)
        {
            this._host = _host;
            this._InventoryManager = _InventoryManager;
        }



        public ActionResult Index()
        {

            try
            {
                var host = _host.GetAll();
                var hlvm = new HostListViewModel
                {
                    Hosts = host

                };
                return View(hlvm);
            }
            catch (Exception ex)
            {

                //Log exception
                return View(ex.Message, "Error");

            }

        }
        [HttpGet]
        public ActionResult Create()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult Create(HostViewModel hvm)
        {
            
            if (ModelState.IsValid)
            {

                    var host = new Host
                    {
                        HostName = hvm.HostName,
                        IpAddress = hvm.IpAddress,
                        CPU = hvm.CPU,
                        DiskSpace = hvm.DiskSpace,
                        RAM = hvm.RAM,
                        OperatingSystem = hvm.OperatingSystem,
                        Hypervisor = hvm.Hypervisors,
                        Date = hvm.Date

                    };

                    _host.Add(host);
                    _host.SaveChanges();
                    TempData["Success"] = "Added Successfully!";

                    return RedirectToAction("Index");
            }

            else
            {

                    return View(hvm);
            }

        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Host host = _host.Find(x => x.id == id).FirstOrDefault();
            if (host == null)
            {
                return HttpNotFound();
            }
            return View(host);
        }
        [HttpPost]
        public ActionResult Edit(HostViewModel hvm)
        {
            var host = new Host
            {
                HostName = hvm.HostName,
                IpAddress = hvm.IpAddress,
                CPU = hvm.CPU,
                DiskSpace = hvm.DiskSpace,
                RAM = hvm.RAM,
                OperatingSystem = hvm.OperatingSystem,
                Hypervisor = hvm.Hypervisors,
                Date = hvm.Date

            };

            if (TryUpdateModel(host))
            {
                _host.Edit(host);
                _host.SaveChanges();
                TempData["Success"] = "Edited Successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Host host = _host.Find(x => x.id == id).FirstOrDefault();
            return View(host);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Host host = _host.Find(x => x.id == id).FirstOrDefault();
            _host.Remove(host);
            _host.SaveChanges();
            TempData["Success"] = "Deleted Successfully!";
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            Host host = _host.Find(x => x.id == id).FirstOrDefault();
            return View(host);
        }
        public ActionResult Export()
        {

            var list = _host.GetAll().ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Id";
            ws.Cells["B1"].Value = "Host Name";
            ws.Cells["C1"].Value = "IP Address";
            ws.Cells["D1"].Value = "CPU";
            ws.Cells["E1"].Value = "RAM";
            ws.Cells["F1"].Value = "Disk Space";
            ws.Cells["G1"].Value = "Operating System";
            ws.Cells["H1"].Value = "Hypervisor";
            ws.Cells["I1"].Value = "Date";



            //ws.Cells["E1"].Value = "Server Name";


            int rowStart = 2;
            foreach (var item in list)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.id;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.HostName;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.IpAddress;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.CPU;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.RAM;

                ws.Cells[string.Format("F{0}", rowStart)].Value = item.DiskSpace;

                ws.Cells[string.Format("G{0}", rowStart)].Value = item.OperatingSystem;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.Hypervisor;

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
            var list = _host.GetAll().ToList();

            var viewAsPdf = new ViewAsPdf("Index", list)

            {
                FileName = "HostProject.pdf"
            };

            return viewAsPdf;
        }

    }
}
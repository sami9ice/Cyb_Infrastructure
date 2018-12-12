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
    //[Authorize(Roles = "Administrator")]

    //[Authorize(Roles = "UserRole")]
    public class CredentialController : Controller
    {
            public CredentialController()
            {

            }
            private readonly ICredManager _cred;
            private readonly IInventoryManager InventoryManager;
            private readonly IHostManager hostManager;



            public CredentialController(ICredManager _cred, IInventoryManager InventoryManager, IHostManager hostManager)
            {
                this._cred = _cred;
                this.InventoryManager = InventoryManager;
                this.hostManager = hostManager;
            }
        //[Authorize(Roles ="mikel")]
        //[Authorize(Roles = "UserRole")]

        public ActionResult Index()

            {


                try
                {
                    var _creds = _cred.GetAll();
                    var Clvm = new CredSetupListViewModel
                    {
                        CredentialSetups = _creds
                    };
                    return View(Clvm);
                }
                catch (Exception ex)
                {

                    //Log exception
                    return View(ex.Message, "Error");

                }

            }


        [HttpGet]
        [Authorize(Roles = "RoleAdmin")]
        public ActionResult Create()
            {
                var Inventory = InventoryManager.GetAll().ToList();
                var Host = hostManager.GetAll().ToList();



                CredSetupModel cred = new CredSetupModel
                {
                    Hosts = Host,
                    Inventories = Inventory
                };

                return View(cred);
            }

            [HttpPost]
            public ActionResult Create(CredSetupModel cvm)
            {
                if (ModelState.IsValid)
                {
                    var cred = new CredentialSetup
                    {
                        ServerUsername=cvm.ServerUsername,
                        ServerPassword = cvm.ServerPassword,
                        HostUsername = cvm.HostUsername,
                        HostPassword = cvm.HostPassword,
                        InventoryId = cvm.InventoryId,
                        HostId = cvm.HostId,
                        Date = cvm.Date
                       
                        //Locations = uvm.Locations
                    };

                    _cred.Add(cred);
                    _cred.SaveChanges();
                    TempData["Success"] = "Added Successfully!";

                    return RedirectToAction("Index");
                }


            var Inventory = InventoryManager.GetAll().ToList();
            var Host = hostManager.GetAll().ToList();

            CredSetupModel credModel = new CredSetupModel
            {
                Hosts = Host,
                Inventories = Inventory
            };

            return View(credModel);
            }

        [HttpGet]
        [Authorize(Roles = "RoleAdmin")]
        public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CredentialSetup cred = _cred.Find(x => x.Id == id).FirstOrDefault();
                ViewBag.Hosts = hostManager.GetAll();
                ViewBag.Inventories = InventoryManager.GetAll();
                if (cred == null)
                {
                    return HttpNotFound();
                }
                return View(cred);
            }
            [HttpPost]
            public ActionResult Edit(CredSetupModel cvm)
            {

              //if (ModelState.IsValid)
              //{
                var cred = new CredentialSetup
                {
                    ServerUsername = cvm.ServerUsername,
                    ServerPassword = cvm.ServerPassword,
                    HostUsername = cvm.HostUsername,
                    HostPassword = cvm.HostPassword,
                    InventoryId = cvm.InventoryId,
                    HostId = cvm.HostId,
                    Date = cvm.Date


                    //Locations = uvm.Locations
                };
                if (TryUpdateModel(cred))
                {
                    _cred.Edit(cred);
                    _cred.SaveChanges();
                    TempData["Success"] = "Edited Successfully!";
                    return RedirectToAction("Index");
                }


                  
              
                ViewBag.message = "Fill all parameters";
                return View();
            }

        [HttpGet]
        [Authorize(Roles = "RoleAdmin")]
        public ActionResult Delete(int? id)
            {
            CredentialSetup cred = _cred.Find(x => x.Id == id).FirstOrDefault();
            return View(cred);
            }
            [HttpPost]
            public ActionResult Delete(int id)
            {
            CredentialSetup cred = _cred.Find(x => x.Id == id).FirstOrDefault();
            _cred.Remove(cred);
            _cred.SaveChanges();
            TempData["Success"] = "Deleted Successfully!";
                return RedirectToAction("Index");
            }
            public ActionResult Details(int? id)
            {
            CredentialSetup cred = _cred.Find(x => x.Id == id).FirstOrDefault();
            return View(cred);
            }

            public ActionResult Export()
            {

                var list = _cred.GetAll().ToList();
                ExcelPackage pck = new ExcelPackage();
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

                ws.Cells["A1"].Value = "Id";
                ws.Cells["B1"].Value = "Host Username";
                ws.Cells["C1"].Value = "Host Password";
                ws.Cells["D1"].Value = "Server Username";
                ws.Cells["E1"].Value = "Server Password";
                ws.Cells["F1"].Value = "List Of Servers";
                ws.Cells["G1"].Value = "List Of Host";
                ws.Cells["I1"].Value = "Date";


            //ws.Cells["E1"].Value = "Address";


            int rowStart = 2;
                foreach (var item in list)
                {
                    ws.Cells[string.Format("A{0}", rowStart)].Value = item.Id;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = item.HostUsername;
                    ws.Cells[string.Format("C{0}", rowStart)].Value = item.HostPassword;
                    ws.Cells[string.Format("D{0}", rowStart)].Value = item.ServerUsername;
                    ws.Cells[string.Format("E{0}", rowStart)].Value = item.ServerPassword;
                    ws.Cells[string.Format("F{0}", rowStart)].Value = item.Inventory.ServerName;
                    ws.Cells[string.Format("G{0}", rowStart)].Value = item.Host.HostName;

                    ws.Cells[string.Format("H{0}", rowStart)].Value = item.Date;
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
                var list = _cred.GetAll().ToList();

                var viewAsPdf = new ViewAsPdf("Index", list)

                {
                    FileName = "CredentialsProject.pdf"
                };

                return viewAsPdf;
            }
        
    }
}
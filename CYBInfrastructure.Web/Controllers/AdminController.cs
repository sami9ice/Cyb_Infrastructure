using CYBInfracstructure.DataStructure;
using CYBInfracstructure.DataStructure.Entities;
using CYBInfrastructure.Core.Interfaces;
using CYBInfrastructure.Web.Model;
using CYBInfrastructure.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CYBInfrastructure.Web.Controllers
{
    [Filter.AuthorizeUserRoles]

    public class AdminController : Controller
    {

        public AdminController()
        {

        }
        private readonly IUsersInRoleManager _usersInRole;
        private readonly IRoleManager _roleManager;
        private readonly IUserAccountManager UserManager;

        public AdminController(IUsersInRoleManager _usersInRole, IRoleManager _roleManager, IUserAccountManager UserManager)
        {
            this._usersInRole = _usersInRole;
            this._roleManager = _roleManager;
            this.UserManager = UserManager;
        }


        public ActionResult Index()

        {

            try
            {

                //var locations = _usersInRole.GetAll();
                var locations = UserManager.GetAll();
                var llvm = new UserAccountListViewModel
                {
                    UserAccounts = locations
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
        //public ActionResult Edit1(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CYBInfracstructure.DataStructure.Entities.UsersInRoles host = _usersInRole.Find(x => x.Id == id).FirstOrDefault();
        //    ViewBag.role = _roleManager.GetAll();

        //    if (host == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(host);
        //}
        //[HttpPost]
        //public ActionResult Edit1(Model.UsersInRoles dvm)
        //{
        //    var dept = new CYBInfracstructure.DataStructure.Entities.UsersInRoles

        //    {
        //        Id = dvm.Id,
        //        RoleId = dvm.RoleId,
        //        UserID = dvm.UserId,
        //        Role = dvm.Role,
                
        //        UserAccount = dvm.UserAccount

        //    };
           
        //    if (TryUpdateModel(dept))
        //    {
        //        _usersInRole.Edit(dept);
        //        _usersInRole.SaveChanges();
        //        TempData["Success"] = "Edited Successfully!";
        //        return RedirectToAction("Index");
        //    }
           
        //    return View();
        //}
        [HttpGet]
        public ActionResult Edits(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CYBInfracstructure.DataStructure.Entities.UserAccount host = UserManager.Find(x => x.UserID == id).FirstOrDefault();
            //ViewBag.role = _roleManager.GetAll();

            if (host == null)
            {
                return HttpNotFound();
            }
            return View(host);
        }

        [HttpPost]
        public ActionResult Edits([Bind(Include = "UserID,StaffID,StaffName,LastName,Email,Password,ConfirmPassword")]Models.UserAccountModel user)
        {
            var dept = new CYBInfracstructure.DataStructure.Entities.UserAccount

            {
                UserID = user.UserID,

                StaffID = user.StaffID,
                StaffName = user.StaffName,
                Email = user.Email,
                Password = user.Password,
                ConfirmPassword=user.ConfirmPassword
               

            };

            //if (TryUpdateModel(dept))
            //{
            //    UserManager.Edit(dept);
            //    UserManager.SaveChanges();
            //    TempData["Success"] = "Edited Successfully!";
            //    return RedirectToAction("Index");
            //}
            UserManager.Edit(dept);
            UserManager.SaveChanges();
            TempData["Success"] = "Edited Successfully!";
            return RedirectToAction("Index");

            return View();
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            CYBInfracstructure.DataStructure.Entities.UsersInRoles host = _usersInRole.Find(x => x.Id == id).FirstOrDefault();
            return View(host);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            CYBInfracstructure.DataStructure.Entities.UsersInRoles host = _usersInRole.Find(x => x.Id == id).FirstOrDefault();
            _usersInRole.Remove(host);
            _usersInRole.SaveChanges();
            TempData["Success"] = "Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}
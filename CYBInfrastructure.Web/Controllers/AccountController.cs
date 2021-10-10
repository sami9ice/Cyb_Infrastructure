using System;
using CYBInfrastructure.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CYBInfracstructure.DataStructure;
using CYBInfracstructure.DataStructure.Entities;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Net.Mail;
using System.Net;
using System.Web.Helpers;
using System.Web.Security;
using CYBInfrastructure.Web.Model;
using System.Text.RegularExpressions;
using CYBInfrastructure.Core.Interfaces;
using System.Data.Entity.Infrastructure;

namespace CYBInfrastructure.Web.Controllers
{
    //[AllowAnonymous]
    public class AccountController : Controller

    {
        public AccountController()
        {

        }
        private readonly IUsersInRoleManager _usersInRole;
        public AccountController(IUsersInRoleManager _usersInRole)
        {
            this._usersInRole = _usersInRole;
        }
        CYBInfrastrctureContext db = new CYBInfrastrctureContext();

        // GET: Account
        public ActionResult Index(UserAccountListViewModel userAccount)
        {
            using (CYBInfrastrctureContext db = new CYBInfrastrctureContext())
            {
                return View(userAccount);
            }
        }
        [Filter.AuthorizeUserRoles]

        //[Authorize(Roles = "RoleAdmin")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserID,StaffID,StaffName,LastName,Email,Password,ConfirmPassword,ResetPassword,")]
                            UserAccountModel user)
        {
            using (CYBInfrastrctureContext db = new CYBInfrastrctureContext())
            {
                var checkexistance = (from reg in db.UserAccounts where reg.StaffID == user.StaffID select reg);
                if (checkexistance.Count() > 0)
                {
                    ModelState.AddModelError("StaffID", "StaffID already exists, Try another one");
                    return View();
                }

                var checkexistance1 = (from reg in db.UserAccounts where reg.Email == user.Email select reg);
                if (checkexistance1.Count() > 0)
                {
                    ModelState.AddModelError("Email", "Email already exists, Try another one");
                    return View();
                }

                if (!string.IsNullOrEmpty(user.Email))
                {
                    string emailRegex = @"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$";
                    Regex re = new Regex(emailRegex);
                    if (!re.IsMatch(user.Email))
                    {
                        ModelState.AddModelError("Email", "Please Enter Correct Email Address");
                        return View();

                    }

                    else
                    {
                        var dpt = new UserAccount
                        {
                            UserID = user.UserID,

                            StaffID = user.StaffID,
                            StaffName = user.StaffName,
                            Email = user.Email,
                            Password = user.Password,
                            ConfirmPassword = user.ConfirmPassword,
                            ResetPasswordCode = user.ResetPasswordCode,
                            //ActivationCode = user.ActivationCode

                        };

                        db.UserAccounts.Add(dpt);
                        db.SaveChanges();
                        TempData["Success"] = "Registered Successfully";

                        return RedirectToAction("Index", "Admin", new { area = "Profile" });
                    }


                }

                //bool Register = db.UserAccounts.Any(x => x.StaffID == user.StaffID && x.UserID == user.UserID);

                //if (Register == true)
                //{
                //    ModelState.AddModelError("StaffID", "StaffID already exists, Try another one");
                //    return View();
                //}
                //bool Register3 = db.UserAccounts.Any(x => x.Email == user.Email && x.UserID == user.UserID);

                //if (Register3 == true)
                //{
                //    ModelState.AddModelError("Email", "Email already exists, Try another one");
                //    return View();
                //}

                else
                {
                    var dpt = new UserAccount
                    {
                        UserID = user.UserID,

                        StaffID = user.StaffID,
                        StaffName = user.StaffName,
                        Email = user.Email,
                        Password = user.Password,
                        ConfirmPassword = user.ConfirmPassword,
                        ResetPasswordCode = user.ResetPasswordCode,
                        //ActivationCode = user.ActivationCode

                    };

                    db.UserAccounts.Add(dpt);
                    db.SaveChanges();
                    TempData["Success"] = "Registered Successfully";

                    return RedirectToAction("Login", "Account", new { area = "Profile" });
                }


            }




            return View(user);

        }


        //public class CustomAuthorizeAttribute : AuthorizeAttribute
        //{
        //    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //    {
        //        if (filterContext.HttpContext.User.Identity.IsAuthenticated)
        //        {
        //            filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
        //        }
        //        else
        //        {
        //            base.HandleUnauthorizedRequest(filterContext);
        //        }
        //    }
        //}



        [HttpGet]
        public ActionResult Login()
        {
            if (Session["SuperAdmin,Admin,UserRole"] != null)
            {
                return RedirectToAction("Index", "Location");
            }
            else
            {
                return View();

            }
        }
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            try
            {
               var  usr = db.UsersInRole.Where(u => u.UserAccount.StaffID == model.StaffId && u.UserAccount.Password == model.Password).ToList();
                if (usr != null)
                {
                    foreach (var item in usr)
                    {
                        if (item.Role.RoleName == "SuperAdmin")
                        {
                            Session["SuperAdmin"] = true;
                            return RedirectToAction("Index", "Location");

                        }

                        if (item.Role.RoleName == "Admin")
                        {
                            Session["Admin"] = true;

                            return RedirectToAction("Index", "Location");
                        }
                        if (item.Role.RoleName == "UserRole")
                        {
                            Session["UserRole"] = true;

                            return RedirectToAction("Index", "Location");
                        }



                    }





                    //Session["UserID"] = usr.UserID.ToString();
                    //Session["StaffID"] = usr.StaffID.ToString();
                    //if (Roles.IsUserInRole(usr., "AdminRole") )
                    //{
                    //    return RedirectToAction("Index", "Location");
                    //}
                    //if (Roles.IsUserInRole(usr.StaffID, "UserRole"))
                    //{
                    //    return RedirectToAction("Index", "Location");
                    //}





                    //return RedirectToAction("Index", "Location");


                }


                if (usr != null)
                {

                    var checkexistance = (from reg in db.UserAccounts where reg.Password == model.Password select reg);
                    if (checkexistance.Count() == 0)
                    {
                        ModelState.AddModelError("Password", "Password is wrong");
                        return View();
                    }
                    //else if (usr != null)
                    //{
                    //   ModelState.AddModelError("", "Not Assigned a Role Yet, Contact Your Admin.");

                    //   return View();
                    //}

                }


                ModelState.AddModelError("", "Not Assigned a Role Yet or Staff Id Does not exist, Contact Your Admin.");


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",ex.Message);

                return View(returnUrl);

            }

            //var usr = db.UsersInRole.Where(u => u.UserAccount.StaffID == model.StaffId && u.UserAccount.Password == model.Password).ToList();

            //var usr = (from user in db.Set<UsersInRoles>()
            //           where user.StaffID == model.StaffId
            //           where user.Password == model.Password
            //           select user).FirstOrDefault();


            //return View();






            // ModelState.AddModelError("", "Username or Password is wrong.");


            return View(returnUrl);

        }


        //public ActionResult RedirectToDefault()
        //{

        //    String[] roles = Roles.GetRolesForUser();
        //    if (roles.Contains("RoleAdmin"))
        //    {
        //        return RedirectToAction("Index", "Location");
        //    }
        //    else if (roles.Contains("UserRole"))
        //    {
        //        return RedirectToAction("Index", "Department");
        //    }
        //    else if (roles.Contains("PublicUser"))
        //    {
        //        return RedirectToAction("Index", "PublicUser");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}

        public ActionResult LoggedIn()
        {
            if (Session["StaffID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult Logout()
        {
            Session["SuperAdmin,UserRole,Admin"] = null;
            return RedirectToAction("Login", "Account");
        }

        [NonAction]

        public void SendVerificationLinkEmail(string Email, string activationCode, string emailFor = "VerifyAccount")
        {
            var verifyUrl = "/Account/" + emailFor + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("no-reply@cyberspace.net.ng", "CYB Infrastructure");
            var toEmail = new MailAddress(Email);
            var fromEmailPassword = "Billing123";// Replace with actual passoword
            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount")
            {
                subject = "Your account is successfully created!";

                body = "<br/>br/> we are excited to tell you that your Cyb Infrastructure account is" +
                    "Successfully created. please click on the link below to verify your account" +
                    "<br/><br/><a href ='" + link + "'> " + link + "</a>";
            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "Hi,<br/><br/> We got request to reset your account password. Please click on the below link to reset your password" +
                    "<br/><br/><a href = " + link + "> Reset Password link</a>";
            }
            //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient
            //{
            //    Host = Emailer.Host,
            //    Port = Emailer.Port,
            //    EnableSsl = Emailer.RequireSSL,
            //    UseDefaultCredentials = false,
            //    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
            //    Credentials = creds
            //}



            var smtp = new SmtpClient
            {
                Host = "smtp.office365.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)

            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true

            })
                smtp.Send(message);

        }


        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(string Email)
        {
            //Verify Email ID
            //Generate Reset password link
            //send Email
            string message = "";
            //bool status = false;


            using (CYBInfrastrctureContext db = new CYBInfrastrctureContext())
            {
                var account = db.UserAccounts.Where(a => a.Email == Email).FirstOrDefault();
                if (account != null)
                {
                    //send email for reset password
                    string resetCode = Guid.NewGuid().ToString();
                    SendVerificationLinkEmail(account.Email, resetCode, "ResetPassword");
                    account.ResetPasswordCode = resetCode;
                    //this line i have added here to avoid confirm password not match issue, as

                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    message = "password link has been sent to your email Id";

                }
                else
                {
                    message = "Account not found";
                }

            }

            ViewBag.Message = message;

            return View();
        }


        public ActionResult ResetPassword(string id)
        {
            using (CYBInfrastrctureContext db = new CYBInfrastrctureContext())
            {
                var user = db.UserAccounts.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
                if (user != null)
                {
                    ResetPasswordModel model = new ResetPasswordModel();
                    model.ResetCode = id;
                    return View(model);
                }
                else
                {
                    return HttpNotFound();
                }
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                using (CYBInfrastrctureContext db = new CYBInfrastrctureContext())
                {
                    var user = db.UserAccounts.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                    if (user != null)
                    {
                        //user.Password = Crypto.Hash(model.NewPassword);
                        user.Password = model.NewPassword;
                        user.ResetPasswordCode = "";
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.SaveChanges();
                        message = "New password updated successfully";
                    }
                }
            }
            else
            {
                message = "Something invalid";
            }

            ViewBag.Message = message;
            return View(model);
        }

        //[Authorize(Roles ="RoleAdmin")]
        [HttpGet]
        //[AuthorizeUserAccessLevel(UserRole = "SuperAdmin")]
        [Filter.AuthorizeUserRoles]

        public ActionResult RoleCreate()

        {


            return View(new CYBInfracstructure.DataStructure.Entities.Role());

        }



        [HttpPost]

        public ActionResult RoleCreate(CYBInfracstructure.DataStructure.Entities.Role role)
        {

            if (ModelState.IsValid)

            {
                bool RoleCreate = db.Roles.Any(x => x.RoleName == role.RoleName && x.RoleId == role.RoleId);

                if (RoleCreate == true)
                {
                    ModelState.AddModelError("RoleName", "RoleName already exists, Try another one");
                    return View(role);
                }

                //if (Roles.RoleExists(role.RoleName))

                //{

                //    ModelState.AddModelError("Error", "Rolename already exists");

                //    return View(role);

                //}

                else

                {


                    //Roles.CreateRole(role.RoleName);
                    db.Roles.Add(role);
                    db.SaveChanges();
                    TempData["Success"] = "Registered Successfully";


                    return RedirectToAction("RoleCreate", "Account");

                }

            }

            else

            {

                ModelState.AddModelError("Error", "Please enter Username and Password");

                {

                    return View(role);

                }

            }


        }

        //[Authorize(Roles = "RoleAdmin")]

        [HttpGet]
        [Filter.AuthorizeUserRoles]

        public ActionResult DisplayAllRoles()

        {

            IEnumerable<CYBInfracstructure.DataStructure.Entities.Role> ListRoles;

            using (CYBInfrastrctureContext db = new CYBInfrastrctureContext())

            {

                ListRoles = db.Roles.ToList();

            }

            return View(ListRoles);

        }



        [NonAction]

        public List<SelectListItem> GetAll_Roles()

        {

            List<SelectListItem> listrole = new List<SelectListItem>();

            listrole.Add(new SelectListItem { Text = "select", Value = "0" });

            using (CYBInfrastrctureContext db = new CYBInfrastrctureContext())

            {

                foreach (var item in db.Roles)

                {

                    listrole.Add(new SelectListItem { Text = item.RoleName, Value = item.RoleName });

                }

            }

            return listrole;


        }

        [NonAction]
        //[Filter.AuthorizeUserRoles]

        public List<SelectListItem> GetAll_Users()

        {

            List<SelectListItem> listuser = new List<SelectListItem>();

            listuser.Add(new SelectListItem { Text = "Select", Value = "0" });



            using (CYBInfrastrctureContext db = new CYBInfrastrctureContext())

            {

                foreach (var item in db.UserAccounts)

                {

                    listuser.Add(new SelectListItem { Text = item.StaffID, Value = item.StaffID });

                }

            }

            return listuser;

        }

        //[Authorize(Roles = "RoleAdmin")]

        [HttpGet]
        [Filter.AuthorizeUserRoles]

        public ActionResult RoleAddToUser()

        {

            AssignRoleVM objvm = new AssignRoleVM();

            objvm.RolesList = GetAll_Roles();

            objvm.Userlist = GetAll_Users();

            return View(objvm);

        }



        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult RoleAddToUser(AssignRoleVM objvm)

        {

            if (objvm.RoleName == "0")

            {

                ModelState.AddModelError("RoleName", "Please select RoleName");

            }

            if (objvm.UserID == "0")

            {

                ModelState.AddModelError("Username", "Please select Username");

            }

            if (ModelState.IsValid)

            {

                if (Get_CheckUserRoles(objvm.UserID) == true)

                //if (objIAccountData.Get_CheckUserRoles(objvm.UserID) == true)

                {


                    ViewBag.ResultMessage = "This user already has the role specified !";

                }

                else

                {

                    //int val = 0;
                    //var Username = GetUserName_BY_UserID(Int32.TryParse(objvm.UserID));

                    //int GetUserName_BY_UserID;
                    //string Username = objvm.UserID;

                    //var Username  = Int32.TryParse(objvm.UserID, out GetUserName_BY_UserID) ;
                    var result = GetUserName_BY_UserID(objvm.UserID);
                    Roles.AddUserToRole(result, objvm.RoleName);




                    //if (objvm != null)
                    //{
                    //    var checkexistance = (from reg in db.UsersInRole where reg.UserID.ToString() == objvm.RoleName select reg);
                    //    if (checkexistance.Count() > 0)
                    //    {
                    //        //ModelState.AddModelError("RoleName", "This user already has the role specified !");
                    //        ViewBag.ResultMessage = "This User is already assigned to the role specified!";

                    //    }


                    //}
                    //else
                    //{
                    //    ViewBag.ResultMessage = "Username has been added to the role successfully !";

                    //}


                    //CYBInfracstructure.DataStructure.Entities.UsersInRoles.ReferenceEquals(Username, objvm.RoleName);

                    ViewBag.ResultMessage = "Username has been added to the role successfully !";

                }

                objvm.RolesList = GetAll_Roles();

                objvm.Userlist = GetAll_Users();

                return View(objvm);

            }

            else

            {

                objvm.RolesList = GetAll_Roles();

                objvm.Userlist = GetAll_Users();

            }

            return View(objvm);

        }

        private bool Get_CheckUserRoles(string userID)
        {
            using (CYBInfrastrctureContext context = new CYBInfrastrctureContext())

            {

                var data = (from WR in context.UsersInRole

                            join R in context.Roles on WR.RoleId equals R.RoleId

                            where WR.Role.RoleName == userID

                            orderby R.RoleId

                            select new

                            {

                                WR.UserID

                            }).Count();



                if (data > 0)

                {

                    return true;

                }

                else

                {

                    return false;

                }

            }
        }

        //public bool Get_CheckUserRoles(int UserId)

        //{

        //    using (CYBInfrastrctureContext context = new CYBInfrastrctureContext())

        //    {

        //        var data = (from WR in context.UsersInRole

        //                    join R in context.Roles on WR.RoleId equals R.RoleId

        //                    where WR.UserId == UserId

        //                    orderby R.RoleId

        //                    select new

        //                    {

        //                        WR.UserId

        //                    }).Count();



        //        if (data > 0)

        //        {

        //            return true;

        //        }

        //        else

        //        {

        //            return false;

        //        }

        //    }



        //}


        public string GetUserName_BY_UserID(string UserName)

        {

            using (CYBInfrastrctureContext context = new CYBInfrastrctureContext())

            {

                var result = (from UP in context.UserAccounts

                              where UP.StaffID == UserName

                              select UP.StaffID).SingleOrDefault();

                return result;






            }



        }

        [Filter.AuthorizeUserRoles]

        [HttpGet]

        public ActionResult DisplayAllUserroles()

        {


            AllroleandUser objru = new AllroleandUser();

            objru.AllDetailsUserlist = Get_StaffID_And_Rolename();

            return View(objru);
        }

        [NonAction]

        public List<AllroleandUser> Get_StaffID_And_Rolename()

        {

            using (CYBInfrastrctureContext db = new CYBInfrastrctureContext())

            {

                var Alldata = (from User in db.UserAccounts

                               join WU in db.UsersInRole on User.UserID equals WU.UserID

                               join WR in db.Roles on WU.RoleId equals WR.RoleId


                               select new AllroleandUser { UserName = User.StaffID, RoleName = WR.RoleName, StaffName = User.StaffName }).ToList();



                return Alldata;



            }

        }


        //[HttpGet]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CYBInfracstructure.DataStructure.Entities.UsersInRoles location = _usersInRole.SelectList(x => x.Id == id).FirstOrDefault();
        //    if (location == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(location);
        //}
        // public ActionResult Edit(Model.UsersInRoles dvm)
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
        // }




        //  [NonAction]
        //public string GetRoleBy_UserID(string UserId)
        //{
        //    return objIAccountData.GetRoleByUserID(UserId);
        //}

        //[NonAction]
        //public string GetUserID_By_UserName(string UserName)
        //{
        //    return objIAccountData.GetUserID_By_UserName(UserName);
        //}


    }

}







//[HttpGet]
//public ActionResult RegisterRole()
//{
//    ViewBag.Role = new SelectList(db.UserAccounts.ToList(), "Roles", "Roles");
//    ViewBag.UserName = new SelectList(db.UserAccounts.ToList(), "Username", "Username");
//    return View();
//}
//[HttpPost]
//[AllowAnonymous]
//[ValidateAntiForgeryToken]
//public async Task<ActionResult>RegisterRole (UserAccountModel model, UserAccount user)
//{
//    var userId = db.UserAccounts.Where(i => i.Username == user.Username).Select(s => s.UserID);
//    string updateId = "";
//    foreach (var i in userId)
//    {
//        updateId = i.ToString();
//    }
//    //await this.db.UserAccounts.AddToRoleAsync(updateId, model.Roles);
//    return RedirectToAction("Index", "Home");
//}












//[HttpPost]
//public ActionResult Register(UserAccountModel user)
//{
//    if (ModelState.IsValid)
//    {
//        using (CYBInfrastrctureContext db = new CYBInfrastrctureContext())


//        {


//            var dpt = new UserAccount
//            {
//                UserID = user.UserID,

//                FirstName = user.FirstName,
//                LastName = user.LastName,
//                Email = user.Email,
//                Username = user.Username,
//                Password = user.Password,
//                ConfirmPassword = user.ConfirmPassword
//            };

//            db.UserAccounts.Add(dpt);

//            db.SaveChanges();
//            TempData["Success"] = "Registered Successfully";


//            return RedirectToAction("Login", "Account", new { area = "Profile" });

//        }


//        //ModelState.Clear();
//        //ViewBag.Message = Location.FirstName + "  " + Location.LastName +"  "+ " is successfully registered.";
//        //return RedirectToAction("Login", "Account", new { area = "Profile" });

//    }

//    return View();
//}












//public ActionResult UsernameExists()
//{
//    return View();
//}
//[HttpPost]
//public JsonResult UsernameExists(string Username, int? UserID)
//{

//    using (CYBInfrastrctureContext db = new CYBInfrastrctureContext())

//        if (UserID != null)
//        {

//            if (db.UserAccounts.Any(x => x.Username == Username))
//            {
//                UserAccount existingTabIdea = db.UserAccounts.Single(x => x.Username == Username);
//                if (existingTabIdea.UserID != UserID)
//                {
//                    return Json(false);
//                }
//                else
//                {
//                    return Json(true);
//                }
//            }
//            else
//            {
//                return Json(true);
//            }
//        }
//        else
//        {
//            return Json(!db.UserAccounts.Any(x => x.Username == Username));
//        }
//}

using CYBInfracstructure.DataStructure;
using CYBInfracstructure.DataStructure.Entities;
using CYBInfrastructure.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    public class AuthorizeUserAccessLevel:AuthorizeAttribute
    {

        CYBInfrastrctureContext db = new CYBInfrastrctureContext();

        public string UserRole { get; set; }
        protected override bool AuthorizeCore (HttpContextBase httpContext)
        {

            //var res = db.UsersInRole.Select(u => u.UserAccount.StaffID == u.Role.RoleName).FirstOrDefault();
            //string CurrentUserInRole = res.ToString();

            //if (this.UserRole.Contains(CurrentUserInRole))
            //{
            //    return true;
            //}

            //var res = db.UsersInRole.Where(u=>u.Role.RoleName== u.UserAccount.StaffID).ToString();
            //if (res != null)
            //{
            //    foreach(var item in res)
            //    {

            //        if ( this.UserRole.Contains(item.Role.RoleName))
            //        {
            //            return true;
            //        }
            //        if (this.UserRole.Contains("Admin"))
            //        {
            //            return true;
            //        }
            //        if (this.UserRole.Contains("UserRole"))
            //        {
            //            return true;
            //        }

            //    }
            //}
            //var res  = db.Roles(CurrentUser).FirstOrDefault();
            //string CurrentUserInRole = res.

            //if (this.UserRole.Contains(CurrentUserInRole ))
            //{
            //    return true;
            //}
            //var isAuthorized = base.AuthorizeCore(httpContext);
            //if (! isAuthorized)
            //{
            //    return false;
            //}
            string currentUserRole = "Admin";
            if (this.UserRole.Contains(currentUserRole))
            {
                return true;
            }

            else
            {
                return false;
            }


        }

    }


    public static class BusAdmin
    {
        // for credential set up
        public static string GetUserRole(this HtmlHelper html)
        {

            
            
                 string CurrentUserRole = "SuperAdmin";
                 return CurrentUserRole;
                 
               

            
           

        }
        //for layout
        public static string GetUserRoles(this HtmlHelper html)
        {
            string CurrentUserRoles = "SuperAdmin";
            return CurrentUserRoles;
        }
    }
}
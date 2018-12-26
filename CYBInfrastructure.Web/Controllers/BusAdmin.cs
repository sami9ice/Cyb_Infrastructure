using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CYBInfrastructure.Web.Controllers
{
    
    
        public static class BusAdmin
        {
            // for credential set up... allows password and username to be seen by only the SuperAdmin
            public static string GetUserRole(this HtmlHelper html)
            {



                string CurrentUserRole = "SuperAdmin";
                return CurrentUserRole;






            }
            //for layout.... enables login, register and assign role to user menu to be seen only by the SuperAdmin
            public static string GetUserRoles(this HtmlHelper html)
            {
                string CurrentUserRoles = "SuperAdmin";
                return CurrentUserRoles;
            }
        }
    
}
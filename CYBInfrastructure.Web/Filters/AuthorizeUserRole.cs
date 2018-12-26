using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CYBInfrastructure.Web.Filter
{
    public class AuthorizeUserRoles : System.Web.Mvc.ActionFilterAttribute, System.Web.Mvc.IActionFilter
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {



            if (HttpContext.Current.Session["SuperAdmin"] == null)
            {
                filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    {"Controller","Account" },
                    {"Action","Login" }
                });
            }

            base.OnActionExecuted(filterContext);




        }
    }
}
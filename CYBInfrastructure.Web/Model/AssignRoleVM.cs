using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CYBInfrastructure.Web.Model
{
    public class AssignRoleVM
    {
        [Required(ErrorMessage = " Select Role Name")]

        public string RoleName { get; set; }

        [Required(ErrorMessage = "Select Username")]

        public string UserID { get; set; }

        public List<SelectListItem> Userlist { get; set; }

        public List<SelectListItem> RolesList { get; set; }
    }
}
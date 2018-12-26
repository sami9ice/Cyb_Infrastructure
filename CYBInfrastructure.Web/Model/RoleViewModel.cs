using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CYBInfrastructure.Web.Model
{
    public class RoleViewModel

    {
        [Key]

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        public int RoleId { get; set; }

        [Required(ErrorMessage = "Enter Role name")]

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]

        public string RoleName { get; set; }
        //public string Description { get; set; }


        public virtual List<UsersInRoles> UsersInRoles { get; set; }




    }
}
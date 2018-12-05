using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CYBInfrastructure.Web.Model
{
    public class Role

    {

        [Required(ErrorMessage = "Enter Role name")]

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]

        public string RoleName { get; set; }



        [Key]

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

          public int RoleId { get; set; }

    }
}
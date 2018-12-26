using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CYBInfrastructure.Web.Models
{
    public class LoginModel
    {
        //[Required(ErrorMessage = "Staff ID is required and it must be an integer(0-9)")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Staff ID is required and it must be an integer number (0-9)")]

        public string StaffId { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; internal set; }
    }
}
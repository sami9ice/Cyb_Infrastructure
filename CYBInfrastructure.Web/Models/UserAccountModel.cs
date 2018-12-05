using System;
using CYBInfracstructure.DataStructure.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CYBInfrastructure.Web.Models
{
    public class UserAccountModel
    {


        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string StaffID { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string StaffName { get; set; }

        //[Required(ErrorMessage = "Email is required")]
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Please confrim your Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string ResetPasswordCode { get; set; }
        //[Required(ErrorMessage = "This field is required")]

        //public string ActivationCode { get; set; }

    }
}
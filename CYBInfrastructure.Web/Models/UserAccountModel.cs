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

        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Staff ID is required and it must be an integer number (0-9)")]

        public string StaffID { get; set; }
        [Required(ErrorMessage = "Staff Name is required")]
        public string StaffName { get; set; }

        //[Required(ErrorMessage = "Email is required")]
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; }

        //[Required(ErrorMessage = "Email is required")]
        //[DataType(DataType.EmailAddress)]
        //[Display(Name = "Email address")]
        //[Required(ErrorMessage = "The email address is required")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]

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
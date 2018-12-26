using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfracstructure.DataStructure.Entities
{
   public class UserAccount
    {
       
        [Key]
        public int UserID { get; set; }
        //[Required(ErrorMessage = "Staff ID is required and it must be an integer(0-9)")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Staff ID is required and it must be an integer number (0-9)")]

        public string StaffID { get; set; }
        [Required(ErrorMessage = "Staff Name is required")]
        public string StaffName { get; set; }


        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        ////[EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Please confrim your Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string ResetPasswordCode { get; set; }
        //[Required(ErrorMessage = "This field is required")]
        public virtual List<UsersInRoles> UsersInRoles { get; set; }




     
    }
}

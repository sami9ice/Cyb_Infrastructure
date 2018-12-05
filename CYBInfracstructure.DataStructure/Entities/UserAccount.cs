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
        [Required(ErrorMessage ="First Name is required")]
        public string StaffID   { get; set; }
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

        [Compare("Password", ErrorMessage ="Please confrim your Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string ResetPasswordCode { get; set; }
        //[Required(ErrorMessage = "This field is required")]

        //public string ActivationCode { get; set; }
    }
}

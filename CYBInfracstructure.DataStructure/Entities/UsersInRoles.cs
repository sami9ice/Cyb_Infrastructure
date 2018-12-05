using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CYBInfracstructure.DataStructure.Entities
{
     public class UsersInRoles
    {

        [Key]

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        public int UserId { get; set; }



        public int RoleId { get; set; }
        public List<SelectListItem> RolesList { get; set; }
        public List<SelectListItem> Userlist { get; set; }
    }
}

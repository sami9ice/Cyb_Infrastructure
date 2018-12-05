using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CYBInfrastructure.Web.Model
{
    public class UsersInRoles
    {

        [Key]

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        public int UserId { get; set; }



        public int RoleId { get; set; }

    }
}
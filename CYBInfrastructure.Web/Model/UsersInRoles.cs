using CYBInfracstructure.DataStructure.Entities;
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

        public int Id { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public IEnumerable<Role> Roles { get; set; }
        public int UserId { get; set; }


        public virtual UserAccount UserAccount { get; set; }

        public IEnumerable<UserAccount> UserAccounts { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CYBInfracstructure.DataStructure.Entities;

namespace CYBInfrastructure.Web.Model
{
    public class UsersInRoleListViewModel
    {
        
        
            public IEnumerable<CYBInfracstructure.DataStructure.Entities.UsersInRoles> UsersRole { get; set; }

        
    }
}
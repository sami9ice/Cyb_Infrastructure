using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CYBInfrastructure.Web.Model
{
    public class AllroleandUser
    {
        public string RoleName { get; set; }

        public string UserName { get; set; }

        public IEnumerable<AllroleandUser> AllDetailsUserlist { get; set; }
    }
}
using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CYBInfrastructure.Web.Models
{
    public class HostListViewModel
    {
        public IEnumerable<Host> Hosts { get; set; }

    }
}
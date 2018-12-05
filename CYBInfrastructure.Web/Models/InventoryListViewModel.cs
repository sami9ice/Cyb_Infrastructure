using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CYBInfrastructure.Web.Models
{
    public class InventoryListViewModel
    {
        public IEnumerable<Inventory> Inventories { get; set; }

    }
}
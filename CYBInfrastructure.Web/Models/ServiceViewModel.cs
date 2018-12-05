using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CYBInfrastructure.Web.Models
{
    public class ServiceViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Date { get; set; }


        public int InventoryId { get; set; }

        public string Inventory { get; set; }
        public string Port { get; set; }
        public string URL { get; set; }

        public IEnumerable<Inventory> Inventories { get; set; }
    }
}
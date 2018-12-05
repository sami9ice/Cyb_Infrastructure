using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CYBInfrastructure.Web.Models
{
    public class CredSetupModel
    {
        [Key]
        public int Id { get; set; }
        public string HostUsername { get; set; }
        [Required(ErrorMessage = "Password is required")]
        //[DataType(DataType.Password)]
        public string HostPassword { get; set; }
        public string ServerUsername { get; set; }
        [Required(ErrorMessage = "Password is required")]
        //[DataType(DataType.Password)]
        public string ServerPassword { get; set; }
        public int HostId { get; set; }
        public virtual Host Host { get; set; }

        public IEnumerable<Host> Hosts { get; set; }
        public string Date { get; set; }

        //servername
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }

        public IEnumerable<Inventory> Inventories { get; set; }
    }
}
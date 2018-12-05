using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace CYBInfrastructure.Web.Models
{
    public class LocationViewModel
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "This field is required")]
        public string LocationName { get; set; }
        //[Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }
        public string Date { get; set; }

        public virtual List<Department> Departments { get; set; }
        public virtual List<Unit> Unit { get; set; }
        public virtual List<Inventory> Inventories { get; set; }


    }
}
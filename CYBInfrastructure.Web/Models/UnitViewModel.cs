using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace CYBInfrastructure.Web.Models
{
    public class UnitViewModel
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Unit Name is required")]
        public string UnitName { get; set; }
        //[Required(ErrorMessage = "select a department")]

        public int DepartmentId { get; set; }
        public int LocationId { get; set; }

        public string Date { get; set; }


        public virtual Department Department { get; set; }
        public virtual Location Location { get; set; }


        public IEnumerable<Department> Departments { get; set; }

        public IEnumerable<Location> Locations { get; set; }
        public virtual List<Inventory> Inventories { get; set; }

    }
}
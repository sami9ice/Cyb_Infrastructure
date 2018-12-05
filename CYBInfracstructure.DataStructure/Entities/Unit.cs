using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CYBInfracstructure.DataStructure.Entities
{
    public class Unit
    {
       [Key]
        public int Id { get; set; }
        //[Required(ErrorMessage = "This field is required")]

        public string UnitName { get; set; }
        //[Required(ErrorMessage = "This field is required")]
        public string Date { get; set; }


        public int DepartmentId { get; set; }
       
        public virtual Department Department { get; set; }
       

        public IEnumerable<Department> Departments { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public IEnumerable<Location> Locations { get; set; }
        public virtual List<Inventory> Inventories { get; set; }


        //public virtual List<Department> Department { get; set; }
        //public virtual Department Department { get; set; }
    }
}
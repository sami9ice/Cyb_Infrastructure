using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CYBInfracstructure.DataStructure.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        //[Required(ErrorMessage = "This field is required")]

        public string LocationName { get; set; }
        //[Required(ErrorMessage = "This field is required")]
        public string Date { get; set; }

        public string Description { get; set; }
        public virtual List<Department> Departments { get; set; }
        public virtual List<Unit> Units { get; set; }
        public virtual List<Inventory> Inventories { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CYBInfracstructure.DataStructure.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        //[Required(ErrorMessage = "This field is required")]

        public string DepartmentName { get; set; }
        public string Date { get; set; }

        public bool IsActive { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public IEnumerable<Location> Locations { get; set; }
        public virtual List<Unit> Unit { get; set; }


        //public IEnumerable<Unit> Units { get; set; }


    }
}
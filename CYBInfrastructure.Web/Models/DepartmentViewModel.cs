using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace CYBInfrastructure.Web.Models
{
    public class DepartmentViewModel
    {
        
        public int Id { get; set; }
        //[Required(ErrorMessage = "Department Name is required")]
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }

        public int LocationId { get; set; }
        public string Date { get; set; }


        public virtual Location Location { get; set; }

        public IEnumerable<Location> Locations { get; set; }

       
        public virtual List<Unit> Unit { get; set; }

    }
}
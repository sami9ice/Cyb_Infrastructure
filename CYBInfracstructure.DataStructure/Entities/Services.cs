using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfracstructure.DataStructure.Entities
{
    public class Services
    {
        [Key]
        public int Id { get; set; }
        //[Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        public string Date { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Port { get; set; }
        public string URL { get; set; }
        //severname
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }
        public IEnumerable<Inventory> Inventories { get; set; }
    }
}

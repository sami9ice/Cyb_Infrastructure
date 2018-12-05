using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfracstructure.DataStructure.Entities
{
    public class Host
    {
        [Key]
        public int id { get; set; }
        public string HostName { get; set; }
        public string IpAddress { get; set; }
        public string Date { get; set; }

        public string CPU { get; set; }
        public string RAM { get; set; }
        public string DiskSpace { get; set; }
        public string OperatingSystem { get; set; }

        public Hypervisors Hypervisor { get; set; }
        public IEnumerable<Hypervisors> Hypervisors { get; set; }
        public virtual List<Inventory> Inventories { get; set; }
        public virtual List<CredentialSetup> CredentialSetup { get; set; }
        




    }

    public enum Hypervisors

    {
        Physical,
        Hyperview,
        VirtualMachine
        
    }
}

using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CYBInfrastructure.Web.Models
{
    public class HostViewModel
    {
        public int id { get; set; }
        public string HostName { get; set; }
        public string IpAddress { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string OperatingSystem { get; set; }
        public string Date { get; set; }



        public string DiskSpace { get; set; }
        //public string Username { get; set; }
        //public string Password { get; set; }
        public Hypervisors Hypervisor { get; set; }
        //public IEnumerable<Hypervisor> Hypervisors { get; set; }
        public CYBInfracstructure.DataStructure.Entities.Hypervisors Hypervisors { get; internal set; }

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
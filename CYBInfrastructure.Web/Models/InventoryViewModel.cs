using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CYBInfrastructure.Web.Models
{
    public class InventoryViewModel
    {
        //[Key]
        public int Id { get; set; }
        //[Required(ErrorMessage = "This field is required")]
        [Remote("Create", "VirtualMachine", HttpMethod = "POST", ErrorMessage = "User name already registered.")]

        public string ServerName { get; set; }
        //[Required(ErrorMessage = "This field is required")]


        public string HostName { get; set; }
        //[Required(ErrorMessage = "This field is required")]

        public string PrimaryIP { get; set; }
        public string SecondaryIP { get; set; }
        //[Required(ErrorMessage = "This field is required")]

        public string Description { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public string Date { get; set; }


        public IEnumerable<Location> Locations { get; set; }
        public int HostId { get; set; }
        public virtual Host Host { get; set; }

        public IEnumerable<Host> Hosts { get; set; }

        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }
        public IEnumerable<Unit> Units { get; set; }
        public virtual List<Services> Service { get; set; }
        public string VLAN { get; set; }
        public string Gateway { get; set; }
        public  Environments Environment { get; set; }
        //public IEnumerable<Environments> Environments { get; set; }
        //public  ServerTypes ServerType { get; set; }
        public CYBInfracstructure.DataStructure.Entities.Environments Environments { get; internal set; }
        //public CYBInfracstructure.DataStructure.Entities.ServerTypes ServerTypes { get; internal set; }

        //public IEnumerable<ServerTypes> ServerTypes { get; set; }

    }
    public enum Environments
    {
        Options,
        Staging,
        Production
    }
    //public enum ServerTypes

    //{
    //    VirtualMachine,
    //    Physical
    //}

}


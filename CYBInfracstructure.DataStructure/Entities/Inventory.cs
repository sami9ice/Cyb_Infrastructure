using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Services.Protocols;

namespace CYBInfracstructure.DataStructure.Entities
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        [Remote("Create", "Inventory", HttpMethod = "POST", ErrorMessage = "User name already registered.")]

        public string ServerName { get; set; }
        //[Required(ErrorMessage = "This field is required")]
        public string Date { get; set; }
        public string DescriptionOfServicesOffered { get; set; }


        public string HostName { get; set; }
        //[Required(ErrorMessage = "This field is required")]
        // only one IP
        public string PrimaryIP { get; set; }
        //Allow Many Ip
        public string SecondaryIP { get; set; }
        //[Required(ErrorMessage = "This field is required")]

        public string Description { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public IEnumerable<Location> Locations { get; set; }
        public int HostId { get; set; }
        public virtual Host Host { get; set; }

        public IEnumerable<Host> Hosts { get; set; }

        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }
        public IEnumerable<Unit> Units { get; set; }
        public virtual List<Services> Service { get; set; }
        public virtual List<CredentialSetup> CredentialSetup { get; set; }

        public string VLAN { get; set; }
        public string Gateway { get; set; }
        public  Environments Environment { get; set; }
        public IEnumerable<Environments> Environments { get; set; }
        //public  ServerTypes ServerType { get; set; }
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

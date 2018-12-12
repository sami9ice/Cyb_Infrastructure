using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CYBInfracstructure.DataStructure.Entities;
using Microsoft.AspNet.Identity;

namespace CYBInfracstructure.DataStructure
{
    //public class User : IdentityUser, IUser
    //{

    //}
    public class CYBInfrastrctureContext : DbContext
    {
        public DbSet<Location> Location { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<UserAccount> UserAccounts{ get; set; }
        public DbSet<Services>Services { get; set; }
        public DbSet<Inventory>Inventories { get; set; }
        public DbSet<Host>Hosts { get; set; }
        public DbSet<CredentialSetup> CredentialSetups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UsersInRoles> UsersInRole { get; set; }







        public CYBInfrastrctureContext() : base("CYBInfrastructureConnectionString")
        {
            //Database.SetInitializer(new NKST.Data.Migrations.Configuration());
        }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //public System.Data.Entity.DbSet<CYBInfrastructure.Web.Models.RoleViewModel> RoleViewModels { get; set; }


        //public System.Data.Entity.DbSet<CYBInfrastructure.Web.Models.HostViewModel> HostViewModels { get; set; }

        //public System.Data.Entity.DbSet<CYBInfrastructure.Web.Models.UserAccountModel> UserAccountModels { get; set; }



        //public System.Data.Entity.DbSet<CYBInfrastructure.Web.Models.LocationViewModel> LocationViewModels { get; set; }
    }
}

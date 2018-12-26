using CYBInfrastructure.Core.Interfaces;
using CYBInfrastructure.Core.Managers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Modules
{
    public class UsersInRoleManagerModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IUsersInRoleManager)).To(typeof(UsersInRolesManager));
        }
    }
}

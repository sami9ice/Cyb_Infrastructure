using CYBInfrastructure.Core.Interfaces;
using CYBInfrastructure.Core.Managers;
using CYBInfrastructure.Core.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Modules
{
   public class UserAccountManagerModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IUserAccountManager)).To(typeof(UserAccountManager));
        }
    }
}

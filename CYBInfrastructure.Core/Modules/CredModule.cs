using CYBInfrastructure.Core.Interfaces;
using CYBInfrastructure.Core.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Modules
{
    public class CredModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(ICredRepository)).To(typeof(CredRepository));
        }
    }
}


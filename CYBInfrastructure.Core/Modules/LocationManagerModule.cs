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
    public class LocationManagerModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(ILocationManager)).To(typeof(LocationManager));
        }
    }
}

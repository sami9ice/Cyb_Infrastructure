[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CYBInfrastructure.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CYBInfrastructure.Web.App_Start.NinjectWebCommon), "Stop")]

namespace CYBInfrastructure.Web.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using CYBInfrastructure.Core.Modules;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var modules = new List<INinjectModule>
            {
                new LocationModule(),
                new DepartmentModules(),
                new UnitModule(),
                new ServiceModules(),
                new HostModule(),
                new InventoryModules(),
                new CredModule (),
                new UsersInRoleModule(),
                new RoleModule(),
                new UserAccountModule(),

                new LocationManagerModule(),
                new UnitManagerModule(),
                new DepartmentManagerModules(),
                new ServiceManagerModules(),
                new InventoryManagerModules(),
                new HostManagerModule(),
                new CredManagerModule(),
                new UsersInRoleManagerModule(),
                new RoleManagerModule(),
                new UserAccountManagerModule()
            };

            kernel.Load(modules);
        }        
    }
}
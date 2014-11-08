using HallOfFame.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace HallOfFame.Web
{
    using System;
    using System.Data.Entity;
    using System.Web;

    using HallOfFame.Common.Constants;
    using HallOfFame.Data;
    using HallOfFame.Data.Common.Repositories;
    using HallOfFame.Data.Contracts;
    using HallOfFame.Data.Repositories;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using Telerik.Everlive.Sdk.Core;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
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
            // Data
            kernel.Bind<IHallOfFameData>()
                .To<HallOfFameData>()
                .WithConstructorArgument("context", c => new HallOfFameDbContext());

            kernel.Bind<DbContext>().To<HallOfFameDbContext>();

            kernel.Bind(typeof(IDeletableEntityRepository<>)).To(typeof(DeletableEntityRepository<>));

            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));

            // Image Upload
            kernel.Bind<EverliveApp>()
                .To<EverliveApp>()
                .WithConstructorArgument("apiKey", c => ApiKeys.EverliveAppKey);
        }
    }
}

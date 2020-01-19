namespace NetCoreConf.BCN.API
{
    using Autofac;
    using Microsoft.Extensions.Logging;
    using NetCoreConf.BCN.API.Data;
    using NetCoreConf.BCN.API.Domain;
    using NetCoreConf.BCN.API.Repository;
    using NetCoreConf.BCN.API.Services;

    public partial class Startup
    {
        public ILifetimeScope AutofacContainer { get; private set; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            AddConfigureAutofac(builder);

        }
        private void AddConfigureAutofac(ContainerBuilder builder)
        {
            builder.RegisterType<NetCoreConfServices>().As<INetCoreConfServices>();
            builder.RegisterType<AvengerDomain>().As<IAvengerDomain>();
            builder.RegisterType<AvengerRepository>().As<IAvengerRepository>();
            builder.RegisterType<AvengerDbContext>().AsSelf();

            builder.Register(c =>
            {
                ILoggerFactory loggerFactory = new LoggerFactory();
                return loggerFactory.CreateLogger("logger");
            }).As<ILogger>();
        }
    }
}


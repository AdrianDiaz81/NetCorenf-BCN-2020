namespace NetCoreConf.BCN.API
{
    using Autofac;
    using Microsoft.Extensions.Logging;
    using NetCoreConf.BCN.API.Data;
    using NetCoreConf.BCN.API.Domain;
    using NetCoreConf.BCN.API.Repository;

    public partial class Startup
    {
        public ILifetimeScope AutofacContainer { get; private set; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            AddConfigureAutofac(builder);

        }
        private void AddConfigureAutofac(ContainerBuilder builder)
        {
            builder.RegisterType<AvengerFilmRepository>().As<IAvengerFilmRepository>();
            builder.RegisterType<AvengerRepository>().As<IAvengerRepository>();
            builder.RegisterType<FilmRepository>().As<IFilmRepository>();

            builder.RegisterType<AvengerDomain>().As<IAvengerDomain>();
            builder.RegisterType<FilmDomain>().As<IFilmDomain>();
            builder.RegisterType<AvengerDbContext>().AsSelf();

            builder.Register(c =>
            {
                ILoggerFactory loggerFactory = new LoggerFactory();
                return loggerFactory.CreateLogger("logger");
            }).As<ILogger>();
        }
    }
}


using Autofac;
using Ecom.BuildingBlocks.SharedKernel.Configuration;
using Ecom.Core.Repositories;
using Ecom.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ecom.Infrastructure.Modules
{
    public class InfrastructureModule : Module
    {
        private readonly IConfiguration configuration;
        public InfrastructureModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var asd = configuration.GetSection("AppSettings");
            var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();
            var options = new DbContextOptionsBuilder<EcomContext>()
            .UseSqlServer(appSettings.ConnectionString).Options;
            builder.RegisterType<EcomContext>()
                .AsSelf()
                .InstancePerRequest()
                .InstancePerLifetimeScope()
                .WithParameter(new NamedParameter("options", options));

            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>));
        }
    }
}

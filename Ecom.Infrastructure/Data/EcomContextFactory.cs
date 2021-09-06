using Ecom.BuildingBlocks.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Data
{
    public class EcomContextFactory : IDesignTimeDbContextFactory<EcomContext>
    {
        private IConfigurationRoot _configuration;

        public EcomContextFactory()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            //.AddKeyVault("local");

            _configuration = builder.Build();
        }

        public EcomContext CreateDbContext(string[] args)
        {
            var appSettings = new AppSettings();
            _configuration.GetSection("AppSettings").Bind(appSettings);

            var options = new DbContextOptionsBuilder<EcomContext>()
                //.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                .UseSqlServer(appSettings.ConnectionString)
                .Options;

            return new EcomContext(options);
        }
    }
}

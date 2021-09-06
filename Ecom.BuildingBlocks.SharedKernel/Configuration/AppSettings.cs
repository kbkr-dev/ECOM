using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.BuildingBlocks.SharedKernel.Configuration
{
    public class AppSettings
    {
        public BlobStorageSettings BlobStorageSettings { get; set; }
        public string ConnectionString { get; set; }
        public string ServiceBusConnectionString { get; set; }
    }

    public class BlobStorageSettings
    {
        public string ConnectionString { get; set; }
    }

    public class IdentityServerSettings
    {
        public string Url { get; set; }
        public string Scope { get; set; }
        public string ClientId { get; set; }
    }

    public class IdentityServerClientSettings: IdentityServerSettings
    {
        public string ClientSecret { get; set; }
        public string TokenUrl => $"{Url}/connect/token";
    }

    public class ApiSettings
    {
        public int MyProperty { get; set; }
    }

    public class InternalAPISettings
    {
        public ApiSettings Api { get; set; }
        public IdentityServerClientSettings IdentityServer { get; set; }
        public string AKSUrl { get; set; }
    }
}

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Utility
{
    public class Utility
    {
        public static void InitializeCache()
        {
            IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices(services => services.AddMemoryCache())
            .Build();
            IMemoryCache cache = host.Services.GetRequiredService<IMemoryCache>();
        }

    }
}


using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolkDiet.Core.Infrastructure;

namespace VolkDiet.WebCore.Infrastructure
{
    public static class ServiceCollectionExtensions
    {

        public static void ConfigureServicesOnApp(this IServiceCollection services,
            WebApplicationBuilder builder)
        {


            var engine = EngineContext.Create();

            engine.ConfigureServices(services, builder.Configuration);
        }

    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolkDiet.Core.Infrastructure
{
   
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigurePipeline(this IApplicationBuilder application)
        {
            EngineContext.Current.Configure(application);
        }


        public static void StartEngine(this IApplicationBuilder application)
        {
            var engine = EngineContext.Current;


            var logger = engine.Resolve<ILogger<IEngine>>();
            if (logger != null)
                logger.LogInformation("** Engine started **");


        }
    }
}

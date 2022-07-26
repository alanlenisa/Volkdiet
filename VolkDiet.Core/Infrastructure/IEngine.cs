using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VolkDiet.Core.Infrastructure
{
  
    public interface IEngine
    {
        /// <summary>
        /// Add and configure services
        /// </summary>
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);

        ///// <summary>
        ///// Configure HTTP request pipeline
        ///// </summary>
        ///// <param name="application">Builder for configuring an application's request pipeline</param>
        //void ConfigureRequestPipeline(IApplicationBuilder application);

        /// <summary>
        /// Resolve dep.
        /// </summary>
    
        T Resolve<T>(IServiceScope scope = null) where T : class;

        /// <summary>
        /// Resolve dep.
        /// </summary>
        
        object Resolve(Type type, IServiceScope scope = null);

       


        void ConfigureRequestPipeline(IApplicationBuilder application);

        object ResolveNotRegistered(Type type);

    }
}
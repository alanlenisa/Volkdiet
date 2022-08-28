using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NLog;
using NLog.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace VolkDiet.Core.Infrastructure
{
   
    public class VDEngine : IEngine
    {
        NLog.ILogger _logger;

        public VDEngine()
        {
            _logger = NLog.LogManager./*Setup().LoadConfigurationFromAppSettings().*/GetCurrentClassLogger();
       
        }



        /// <summary>
        /// Get IServiceProvider
        /// </summary>
        /// <returns></returns>
        protected IServiceProvider GetServiceProvider(IServiceScope scope = null)
        {
            if (scope == null)
            {
                var accessor = ServiceProvider?.GetService<IHttpContextAccessor>();
                var context = accessor?.HttpContext;
                return context?.RequestServices ?? ServiceProvider;
            }
            return scope.ServiceProvider;
        }





        public T Resolve<T>(IServiceScope scope = null) where T : class
        {
            return (T)Resolve(typeof(T), scope);
        }

      
        public object Resolve(Type type, IServiceScope scope = null)
        {
            return GetServiceProvider(scope)?.GetService(type);
        }

        /// <summary>
        /// looks all IConfigStartup implementations and run their routine 'Configure'
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public void Configure(IApplicationBuilder application)
        {
            
            ServiceProvider = application.ApplicationServices;

            var typeFinder = new TypeFinder();
            var configStartups = typeFinder.FindClasses(typeof(IConfigStartup));


            var instances = configStartups
                .Select(s => (IConfigStartup)Activator.CreateInstance(s))
                .OrderBy(s => s?.Rank);


            foreach (var instance in instances)
                instance.Configure(application);

        }


        public virtual object ResolveNotRegistered(Type type)
        {
            Exception innerException = null;
            foreach (var constructor in type.GetConstructors())
            {
                try
                {
                    
                    var parameters = constructor.GetParameters().Select(parameter =>
                    {
                        var service = Resolve(parameter.ParameterType);
                        if (service == null)
                        {
                            throw new Exception("??");
                        }
                        return service;
                    });

                   
                    return Activator.CreateInstance(type, parameters.ToArray());
                }
                catch (Exception ex)
                {
                    innerException = ex;
                }
            }

            throw new Exception("???",  innerException);
        }

        /// <summary>
        /// looks all IConfigStartup implementations and run their routine 'ConfigureService'
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEngine>(this);

            var typeFinder =  new TypeFinder(); 
            var configStartups = typeFinder.FindClasses(typeof(IConfigStartup));

           
            var instances = configStartups
                .Select(s => (IConfigStartup)Activator.CreateInstance(s))
                .OrderBy(s => s?.Rank);

           
            foreach (var instance in instances)
                instance.ConfigureServices(services, configuration);

            services.AddSingleton(services);
        }





        /// <summary>
        /// Service provider
        /// </summary>
        public virtual IServiceProvider ServiceProvider { get; protected set; }


    }
}
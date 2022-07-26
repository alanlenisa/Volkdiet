using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VolkDiet.Core.Infrastructure
{
  
    public interface IConfigStartup
    {
        
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);

       
       // void Configure(IApplicationBuilder application);

        /// <summary>
        /// Get  implementation's order
        /// </summary>
        int Rank { get; }
    }
}

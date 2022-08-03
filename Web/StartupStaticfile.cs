


using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Net.Http.Headers;
using VolkDiet.Core;
using VolkDiet.Core.Infrastructure;


namespace VolkDiet
{
    public class StartupStaticfile: IConfigStartup
    {
        public int Rank => 5;

        void staticFileResponse(StaticFileResponseContext context)
        {
          
          
        }
        public void Configure(IApplicationBuilder application)
        {
            application.UseStaticFiles(new StaticFileOptions { OnPrepareResponse = staticFileResponse });

        }


        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
          


        }
    }
}

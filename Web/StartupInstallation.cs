


using VolkDiet.Core;
using VolkDiet.Core.Infrastructure;


namespace VolkDiet
{
    public class StartupInstallation : IConfigStartup
    {
        public int Rank => 10;

        public void Configure(IApplicationBuilder application)
        {
            application.UseMiddleware<Core.InstallServices.InstallMiddleware>();
        }

        
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IWWWHelper, WWWHelper>();


        }
    }
}

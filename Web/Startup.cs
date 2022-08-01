

using VolkDiet.Core.EF;
using VolkDiet.Core.Caching;
using VolkDiet.Core.Infrastructure;
using VolkDiet.Core.Localization;
using VolkDiet.Core.DataServices;

namespace VolkDiet
{
    public class Startup : IConfigStartup
    {
        public int Rank => 100;

        public void Configure(IApplicationBuilder application)
        {
            
        }

        /// <summary>
        /// configure web project services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
           

            services.AddHttpContextAccessor();//https://www.c-sharpcorner.com/forums/httpcontext-is-null

            //database provider selection, setted on appsettings.json
            switch (configuration["DatabaseProvider"])
            {
                case "MsSql":
                    services.AddDbContext<volkdietContext, volkdietMsSqlContext>();
                    break;

                case "PgSql":
                    services.AddDbContext<volkdietContext, volkdietPgSqlContext>();
                    break;
            }

            services.AddSingleton<ICacheManager, MemCacheManager>();



            services.AddScoped<ILocalizationService, LocalizationService>();

            services.AddScoped<ILocalizedStringsService, LocalizedStringsService>();


            services.AddControllersWithViews();
        }
    }
}

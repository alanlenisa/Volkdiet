
using VolkDiet.Core.EF;
using VolkDiet.Core.Infrastructure;

namespace VolkDiet
{
    public class Startup : IConfigStartup
    {
        public int Rank => 100;

        /// <summary>
        /// configure web project services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            switch (configuration["DatabaseProvider"])
            {
                case "MsSql":
                    services.AddDbContext<volkdietContext, volkdietMsSqlContext>();
                    break;

                case "PgSql":
                    services.AddDbContext<volkdietContext, volkdietPgSqlContext>();
                    break;
            }

            services.AddControllersWithViews();
        }
    }
}

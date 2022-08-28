using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VolkDiet.Core.EF
{
    /// <summary>
    /// postgress data provider
    /// </summary>
    public class volkdietPgSqlContext : volkdietContext
    {
        public volkdietPgSqlContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("PgSqlConnection"));
        }
    }
}

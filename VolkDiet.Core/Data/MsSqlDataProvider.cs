using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolkDiet.Core.Data
{
    public class MsSqlDataProvider : IDataProvider
    {
        private string GetConnectionString()
        {
            
        }
        public void CreateDb()
        {
            var builder = new SqlConnectionStringBuilder(GetConnectionString());
            string storedDbName = builder.InitialCatalog;
            builder.InitialCatalog = "master";
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                var query = $"CREATE DATABASE [{storedDbName}]";

                var command = connection.CreateCommand();
                command.CommandText = query;
                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public async Task<bool> DbExistsAsync()
        {
            try
            {
                //TODO
                string connectionString = GetConnectionString();
                await using SqlConnection con=new SqlConnection(connectionString);
                await con.OpenAsync();
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public void InitDb()
        {
            throw new NotImplementedException();
        }

        public string MakeConnString(string database, string server, bool trusted, string user, string password)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource=server,
                InitialCatalog=database,
                IntegratedSecurity=trusted,
                PersistSecurityInfo=false
            };

            if (!trusted)
            {
                builder.UserID = user;
                builder.Password = password;             
            }

            return builder.ConnectionString;

        }
    }
}

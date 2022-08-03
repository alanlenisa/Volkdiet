using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolkDiet.Core.Data
{
    public class PgSqlDataProvider : IDataProvider
    {
        public void CreateDb()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DbExistsAsync()
        {
            throw new NotImplementedException();
        }

        public void InitDb()
        {
            throw new NotImplementedException();
        }

        public string MakeConnString(string database, string server, bool trusted, string user, string password)
        {
            throw new NotImplementedException();
        }
    }
}

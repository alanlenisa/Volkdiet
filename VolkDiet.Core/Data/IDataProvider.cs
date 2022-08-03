using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolkDiet.Core.Data
{
    public interface IDataProvider
    {
        string MakeConnString(string database, string server,bool trusted, string user,string password);

        void CreateDb();

        Task<bool> DbExistsAsync();


        void InitDb();
    }
}

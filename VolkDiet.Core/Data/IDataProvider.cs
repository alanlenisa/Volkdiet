using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolkDiet.Core.Data
{
    public interface IDataProvider
    {
        /// <summary>
        /// set internal connection string
        /// </summary>
        /// <param name="connectionString"></param>
        public void SetConnectionString(string connectionString);

        /// <summary>
        /// build a connection string with parameter (server,db, user...)
        /// </summary>
        /// <param name="database"></param>
        /// <param name="server"></param>
        /// <param name="trusted"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        string MakeConnString(string database, string server,bool trusted, string user,string password);

        /// <summary>
        /// create database
        /// </summary>
        void CreateDb();

        /// <summary>
        /// checks if database exists
        /// </summary>
        /// <returns></returns>
        Task<bool> DbExistsAsync();


        /// <summary>
        /// initialize database:create tables, index, relation, basic data...
        /// </summary>
        void InitDb();
    }
}

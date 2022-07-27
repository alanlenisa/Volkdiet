
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolkDiet.Core.dbcontext;

namespace VolkDiet.Core.Caching
{
 
    public static partial class BaseEntityCacheDefaults<TEntity> where TEntity : VDEntity
    {
        
        public static string EntityName => typeof(TEntity).Name.ToLowerInvariant();

        
        
        public static string Prefix => $"VD.{EntityName}.";

    }
}

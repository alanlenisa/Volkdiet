
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolkDiet.Core.dbcontext;

namespace VolkDiet.Core.Caching
{
    public class CacheService
    {

       public  CachedObject CreateKeyOnCache(CachedObject element, params object[] parameters) 
        {
            CachedObject el = element.Create(CreateCacheObjectParams, parameters);
            el.MinutesInCache = 1;//TODO:read a value from config
            return el;
        }

        private object CreateCacheObjectParams(object arg)
        {
            return arg switch
            {
                VDEntity e => e.Id,
                _ => arg
            };
        }
    }
}

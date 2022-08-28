using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolkDiet.Core.Caching
{
    public interface ICacheManager
    {
        T Get<T>(CachedObject element, Func<T> load);
        Task<T> GetAsync<T>(CachedObject element, Func<Task<T>> load);

        Task SetAsync(CachedObject element, object value);


        CachedObject CreateKeyOnCache(CachedObject element,params object[] parameters);
    }
}

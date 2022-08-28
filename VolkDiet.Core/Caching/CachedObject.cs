
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolkDiet.Core.Caching
{
    public class CachedObject
    {
        public string Key { get; set; }

        public List<string> Prefixes { get; set; } = new List<string>();

        public int MinutesInCache { get; set; } = 10;


        public CachedObject(string key,params string[] pref)
        {
            Key = key;
            Prefixes.AddRange(pref);
        }


        public CachedObject Create(Func<object, object> createParams, params object[] objs) 
        {
            CachedObject c = new CachedObject(Key, Prefixes.ToArray());
            if (!objs.Any())
                return c;
            c.Key = string.Format(c.Key, objs.Select(createParams).ToArray());

            for (var i = 0; i < c.Prefixes.Count; i++)
                c.Prefixes[i] = string.Format(c.Prefixes[i], objs.Select(createParams).ToArray());

            return c;
        }
    }

}

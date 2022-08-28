using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VolkDiet.Core.Infrastructure
{
    public class TypeFinder
    {

        private bool match(string name,string search)
        {
            return Regex.IsMatch(name, search,RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        /// <summary>
        /// find classes of a Type
        /// </summary>
        /// <param name="assingFrom"></param>
        /// <returns></returns>
        public IEnumerable<Type> FindClasses(Type assingFrom)
        {
            var res = new List<Type>();

            //extract assemblies
            List<Assembly> assemblies= new List<Assembly>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (match(assembly.FullName,"^volkdiet"))   
                    assemblies.Add(assembly);

            }

            //searching classes
            foreach (var assembly in assemblies)
            {
                Type[] types = null;

                types=assembly.GetTypes();

                foreach (var type in types)
                {
                    if (!assingFrom.IsAssignableFrom(type))
                        continue;
                    if (type.IsInterface)
                        continue;
                    res.Add(type);

                }

            }

            return res;

        }
    }
}

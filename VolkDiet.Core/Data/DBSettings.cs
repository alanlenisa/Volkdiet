using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolkDiet.Core.Data
{
    public class DBSettings
    {
        /// <summary>
        /// get if database is installed
        /// </summary>
        /// <returns></returns>
        public static bool IsDbInstalled()
        {
            return false;
        }

        public static Dictionary<int, string> GetAllProviders()
        {
            return Enum.GetValues(typeof(ProviderType))
                .Cast<ProviderType>()
                .Where(en => en != ProviderType.NotSet)
                .ToDictionary(en => Convert.ToInt32(en),en => en.ToString());
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolkDiet.Core.dbcontext;

namespace VolkDiet.Core.Localization
{
    public class LocalizedValue:VDEntity
    {
        public int Language { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}

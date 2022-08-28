using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class Lafparameter : dbcontext.VDEntity
    {
       // public int Id { get; set; }
        public string LafAlg { get; set; } = null!;
        public string LafSex { get; set; } = null!;
        public int LafAgeMin { get; set; }
        public int LafAgeMax { get; set; }
        public int LafLvl { get; set; }
        public double LafValue { get; set; }
    }
}

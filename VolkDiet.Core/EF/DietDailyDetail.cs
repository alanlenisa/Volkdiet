using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class DietDailyDetail : dbcontext.VDEntity
    {
        //public int Id { get; set; }
        public int DmeId { get; set; }
        public int AliId { get; set; }
        public double DdeQty { get; set; }

        public virtual Aliment Ali { get; set; } = null!;
        public virtual DietDailyMeal Dme { get; set; } = null!;
    }
}

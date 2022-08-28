using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class DietDailyMeal : dbcontext.VDEntity
    {
        public DietDailyMeal()
        {
            DietDailyDetails = new HashSet<DietDailyDetail>();
        }

       // public int Id { get; set; }
        public int DieId { get; set; }
        public int DmeDay { get; set; }
        public int MeaId { get; set; }
        public DateTime? DmeDate { get; set; }

        public virtual Diet Die { get; set; } = null!;
        public virtual Meal Mea { get; set; } = null!;
        public virtual ICollection<DietDailyDetail> DietDailyDetails { get; set; }
    }
}

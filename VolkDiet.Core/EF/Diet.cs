using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class Diet : dbcontext.VDEntity
    {
        public Diet()
        {
            DietDailyMeals = new HashSet<DietDailyMeal>();
        }

       // public int Id { get; set; }
        public int TenId { get; set; }
        public int UsrId { get; set; }
        public string? DieDesc { get; set; }
        public string? DieNote { get; set; }
        public int? DieRequirement { get; set; }
        public DateTime? DieLastMod { get; set; }
        public double? DiePerCarbs { get; set; }
        public double? DiePerProts { get; set; }
        public double? DiePerFats { get; set; }

        public virtual Tenant Ten { get; set; } = null!;
        public virtual User Usr { get; set; } = null!;
        public virtual ICollection<DietDailyMeal> DietDailyMeals { get; set; }
    }
}

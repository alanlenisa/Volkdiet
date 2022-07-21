using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class Meal : dbcontext.VDEntity
    {
        public Meal()
        {
            DietDailyMeals = new HashSet<DietDailyMeal>();
            DietTemplates = new HashSet<DietTemplate>();
        }

       // public int Id { get; set; }
        public int TenId { get; set; }
        public string? MeaDesc { get; set; }

        public virtual Tenant Ten { get; set; } = null!;
        public virtual ICollection<DietDailyMeal> DietDailyMeals { get; set; }
        public virtual ICollection<DietTemplate> DietTemplates { get; set; }
    }
}

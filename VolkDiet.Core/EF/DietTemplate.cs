using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class DietTemplate : dbcontext.VDEntity
    {
        public DietTemplate()
        {
            DietTemplateDetails = new HashSet<DietTemplateDetail>();
        }

       // public int Id { get; set; }
        public int TenId { get; set; }
        public string? TemDesc { get; set; }
        public double? TemPercCarbs { get; set; }
        public double? TemPercProts { get; set; }
        public double? TemPercFats { get; set; }

        public virtual Meal Ten { get; set; } = null!;
        public virtual ICollection<DietTemplateDetail> DietTemplateDetails { get; set; }
    }
}

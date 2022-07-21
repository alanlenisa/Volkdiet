using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class DietTemplateDetail : dbcontext.VDEntity
    {
       // public int Id { get; set; }
        public int TemId { get; set; }
        public int TedDay { get; set; }
        public int MeaId { get; set; }
        public double TedPercKcal { get; set; }

        public virtual DietTemplate Tem { get; set; } = null!;
    }
}

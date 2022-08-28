using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class FoodIntollerance : dbcontext.VDEntity
    {
        //public int Id { get; set; }
        public int UsrId { get; set; }
        public string FinDesc { get; set; } = null!;
        public int FinSeverity { get; set; }

        public virtual User Usr { get; set; } = null!;
    }
}

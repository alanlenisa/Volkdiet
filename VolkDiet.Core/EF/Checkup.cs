using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class Checkup : dbcontext.VDEntity
    {
       // public int Id { get; set; }
        public int UsrId { get; set; }
        public DateTime? CupDate { get; set; }
        public double? CupHeigth { get; set; }
        public double? CupWeight { get; set; }
        public double? CupLeanMass { get; set; }
        public double? CupFatMass { get; set; }
        public double? CupMis1 { get; set; }
        public double? CupMis2 { get; set; }
        public double? CupMis3 { get; set; }
        public double? CupMis4 { get; set; }

        public virtual User Usr { get; set; } = null!;
    }
}

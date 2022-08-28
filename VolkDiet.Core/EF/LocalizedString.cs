using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class LocalizedString : dbcontext.VDEntity
    {
       // public int Id { get; set; }
        public int? LanId { get; set; }
        public string? ResName { get; set; }
        public string? ResValue { get; set; }

        public virtual Language? Lan { get; set; }
    }
}

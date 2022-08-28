using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class LocalizedTable : dbcontext.VDEntity
    {
        //public int Id { get; set; }
        public int? LanId { get; set; }
        public string? LtbTable { get; set; }
        public string? LtbProperty { get; set; }
        public int? LtbRecordId { get; set; }
        public string? LtbValue { get; set; }

        public virtual Language? Lan { get; set; }
    }
}

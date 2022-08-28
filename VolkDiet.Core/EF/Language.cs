using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class Language : dbcontext.VDEntity
    {
        public Language()
        {
            LocalizedStrings = new HashSet<LocalizedString>();
            LocalizedTables = new HashSet<LocalizedTable>();
            Users = new HashSet<User>();
        }

        //public int Id { get; set; }
        public string? LanName { get; set; }
        public string? LanCulture { get; set; }
        public string? LanImageName { get; set; }
        public int? LanDisplayOrder { get; set; }

        public virtual ICollection<LocalizedString> LocalizedStrings { get; set; }
        public virtual ICollection<LocalizedTable> LocalizedTables { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

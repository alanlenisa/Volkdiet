using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class RolesClaim : dbcontext.VDEntity
    {
       // public int Id { get; set; }
        public int? RolId { get; set; }
        public string? RclName { get; set; }
        public string? RclValue { get; set; }

        public virtual Role? Rol { get; set; }
    }
}

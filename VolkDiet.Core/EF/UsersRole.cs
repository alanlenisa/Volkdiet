using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class UsersRole : dbcontext.VDEntity
    {
        //public int Id { get; set; }
        public int? UsrId { get; set; }
        public int? RolId { get; set; }

        public virtual Role? Rol { get; set; }
        public virtual User? Usr { get; set; }
    }
}

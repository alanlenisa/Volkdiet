using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class Role : dbcontext.VDEntity
    {
        public Role()
        {
            RolesClaims = new HashSet<RolesClaim>();
            UsersRoles = new HashSet<UsersRole>();
        }

       // public int Id { get; set; }
        public string? RolDesc { get; set; }

        public virtual ICollection<RolesClaim> RolesClaims { get; set; }
        public virtual ICollection<UsersRole> UsersRoles { get; set; }
    }
}

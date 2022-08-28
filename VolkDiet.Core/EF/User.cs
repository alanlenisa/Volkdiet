using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class User : dbcontext.VDEntity, dbcontext.ISoftDelEntity
    {
        public User()
        {
            Checkups = new HashSet<Checkup>();
            Diets = new HashSet<Diet>();
            FoodIntollerances = new HashSet<FoodIntollerance>();
            UsersRoles = new HashSet<UsersRole>();
        }

        //public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int TenId { get; set; }
        public int? LanId { get; set; }
        public string? UsrLogin { get; set; }
        public string? UsrEmail { get; set; }
        public DateTime? UsrDtReg { get; set; }
        public string? UsrStep { get; set; }
        public string? UsrPwdHash { get; set; }

        public virtual Language? Lan { get; set; }
        public virtual Tenant Ten { get; set; } = null!;
        public virtual ICollection<Checkup> Checkups { get; set; }
        public virtual ICollection<Diet> Diets { get; set; }
        public virtual ICollection<FoodIntollerance> FoodIntollerances { get; set; }
        public virtual ICollection<UsersRole> UsersRoles { get; set; }
    }
}

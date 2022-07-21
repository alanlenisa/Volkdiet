using System;
using System.Collections.Generic;
using VolkDiet.Core.dbcontext;

namespace VolkDiet.Core.EF
{
    public partial class Tenant :VDEntity, ISoftDelEntity
    {
        public Tenant()
        {
            Diets = new HashSet<Diet>();
            Meals = new HashSet<Meal>();
            Users = new HashSet<User>();
        }

        //public int Id { get; set; }
        public int? LibId { get; set; }
        public bool IsDeleted { get; set; }

        public string? TenDesc { get; set; }
        public bool TenIsTemplate { get; set; }

        public virtual Library? Lib { get; set; }
        public virtual ICollection<Diet> Diets { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

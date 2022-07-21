using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class Library : dbcontext.VDEntity
    {
        public Library()
        {
            Aliments = new HashSet<Aliment>();
            Categories = new HashSet<Category>();
            Tenants = new HashSet<Tenant>();
        }

       // public int Id { get; set; }
        public string? LibDesc { get; set; }

        public virtual ICollection<Aliment> Aliments { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}

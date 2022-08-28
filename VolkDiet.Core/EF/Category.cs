using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class Category : dbcontext.VDEntity
    {
        public Category()
        {
            Aliments = new HashSet<Aliment>();
        }

       // public int Id { get; set; }
        public int LibId { get; set; }
        public string? CatDesc { get; set; }

        public virtual Library Lib { get; set; } = null!;
        public virtual ICollection<Aliment> Aliments { get; set; }
    }
}

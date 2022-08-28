using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolkDiet.Core.dbcontext
{
    /// <summary>
    /// soft-deleted entity
    /// </summary>
    public  interface ISoftDelEntity
    {
        bool IsDeleted { get; set; }

    }
}

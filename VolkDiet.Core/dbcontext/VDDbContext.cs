
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
namespace VolkDiet.Core.dbcontext
{


    /// <summary>
    /// base dbcontext (common from sqlserver,pgsql...)
    /// </summary>
        public partial class VDDbContext : DbContext
        {
            public VDDbContext()
            {
            }

            public VDDbContext(DbContextOptions<VDDbContext> options)
                : base(options)
            {
            }
            public VDDbContext(DbContextOptions options)
                : base(options)
            {
            }

            public override int SaveChanges()
            {
                SoftDeleteFlag();
                return base.SaveChanges();
            }

            public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
            {
                SoftDeleteFlag();
                return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            }

        /// <summary>
        /// manage softdelete
        /// </summary>
            private void SoftDeleteFlag()
            {
                foreach (var entry in ChangeTracker.Entries())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:

                            if (entry.Entity is dbcontext.ISoftDelEntity)
                            {
                                entry.CurrentValues["IsDeleted"] = false;
                            }

                           
                            break;
                        case EntityState.Deleted:
                            if (entry.Entity is dbcontext.ISoftDelEntity)
                            {
                                entry.State = EntityState.Modified;
                                entry.CurrentValues["IsDeleted"] = true;
                            }
                            break;
                      
                    }
                }
            }
        }
  

}

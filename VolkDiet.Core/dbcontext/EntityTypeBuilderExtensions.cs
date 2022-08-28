using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VolkDiet.Core.dbcontext
{
    /// <summary>
    /// extension for EntityTypeBuilder used in EF model creation
    /// </summary>
    public static class EntityTypeBuilderExtensions
    {
        /// <summary>
        /// add reference to IsDeleted field 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static EntityTypeBuilder<TEntity> HasSoftwareDeletion<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class
        {
            if (typeof(ISoftDelEntity).GetTypeInfo().IsAssignableFrom(typeof(TEntity).GetTypeInfo()))
            {
                builder.Property(e => ((ISoftDelEntity)e).IsDeleted).HasColumnName("IsDeleted");
                builder.HasQueryFilter(m => !((ISoftDelEntity)m).IsDeleted);//"select" on code automatic exclude softdeleted
            }
            return builder;
        }

        /// <summary>
        /// add a reference to key id
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static EntityTypeBuilder<TEntity> HasIdentityIdColumn<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : VDEntity
        {
            
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ID");

            return builder;
        }
    }

}

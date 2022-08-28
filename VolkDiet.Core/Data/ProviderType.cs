using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VolkDiet.Core.Data
{
   public enum ProviderType
    {
        [EnumMember(Value = "MsSql")]
        MsSql,

        [EnumMember(Value = "PgSql")]
        PgSql,

        [EnumMember(Value="")]
        NotSet

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VolkDiet.Core.DataServices
{
    /// <summary>
    /// operations in 'LocalizedStrings' table
    /// </summary>
    public interface ILocalizedStringsService
    {
        Task<EF.LocalizedString> GetValueAsync(int language,string name);
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolkDiet.Core.EF;

namespace VolkDiet.Core.DataServices
{
    /// <summary>
    /// operations in 'LocalizedStrings' table
    /// </summary>
    public class LocalizedStringsService : ILocalizedStringsService
    {
        private volkdietContext _context;
        public LocalizedStringsService(volkdietContext context)
        {
            _context = context;
        }
    
        public async Task<LocalizedString> GetValueAsync(int language, string name)
        {
            
            var res = await _context.LocalizedStrings
                .Where(x => x.LanId == language &&
                            x.ResName == name)
                .FirstOrDefaultAsync();

            return res;
        }
    }
}

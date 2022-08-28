using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace VolkDiet.Core.Localization
{
   
    public partial interface ILocalizationService
    {

      
        Task<string> GetResourceAsync(string resourceKey);

        Task<string> GetResourceAsync(string resourceKey, int language,
            string defaultValue = "");


        //public  TPropType GetLocalizedAsync<TEntity, TPropType>(TEntity entity, Expression<Func<TEntity, TPropType>> keySelector) where TEntity:class;
    }   
}
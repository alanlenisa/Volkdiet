

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using VolkDiet.Core.Caching;
using VolkDiet.Core.DataServices;

namespace VolkDiet.Core.Localization
{
    /// <summary>
    /// Provides information about localization
    /// </summary>
    public partial class LocalizationService : ILocalizationService
    {
        private  CachedObject COByNameCacheKey => new("name.{0}-{1}", "name.{0}", BaseEntityCacheDefaults<LocalizedValue>.Prefix);

        protected readonly ILogger<LocalizationService> _logger;
       
        protected readonly ICacheManager _cacheManager;

        private ILocalizedStringsService _localizedStringsService;


        public LocalizationService(ILogger<LocalizationService> logger,
            ICacheManager cacheManager,
            ILocalizedStringsService localizedStringsService ) {

            _logger = logger;
            _cacheManager = cacheManager;
            _localizedStringsService = localizedStringsService;
        }




        ///// <summary>
        ///// Get dictionary,   (name,(language,text))
        ///// </summary>
        ///// <param name="locales"></param>
        ///// <returns></returns>
        //protected virtual Dictionary<string, KeyValuePair<int, string>> ValuesToDict(IEnumerable<LocalizedValue> locales)
        //{
          
        //    var dictionary = new Dictionary<string, KeyValuePair<int, string>>();// <name,<language,text>>
        //    foreach (var l in locales)
        //    {
        //        var name = l.Name.ToLowerInvariant();
        //        if (!dictionary.ContainsKey(name))
        //            dictionary.Add(name, new KeyValuePair<int, string>(l.Language, l.Value));
        //    }

        //    return dictionary;
        //}


        /// <summary>
        /// Get resource localized
        /// TODO:now language is only one, Italian with fixed id 
        /// language will be taken from...(?)
        /// </summary>
        /// <param name="resourceKey"></param>
        /// <returns></returns>
        public virtual async Task<string> GetResourceAsync(string resourceKey)
        {
            var userLanguage = 1;//TODO: read user language or select default/first

            if (userLanguage >=0)
                return await GetResourceAsync(resourceKey, userLanguage);

            return "";
        }


        /// <summary>
        /// Get resource localized from cache. Stored there if not present yet.
        /// </summary>
        /// <param name="resourceKey"></param>
        /// <param name="language"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public virtual async Task<string> GetResourceAsync(string resourceKey, int language,   string defaultValue = "")
        {
            var result = string.Empty;
            if (resourceKey == null)
                resourceKey = string.Empty;
            //?

            var key = _cacheManager.CreateKeyOnCache(COByNameCacheKey, language, resourceKey);
            var value = await _cacheManager.GetAsync(key,async () =>

               await _localizedStringsService.GetValueAsync(language,resourceKey)

            );
            if (value != null)
                result = value.ResValue;

            if (!string.IsNullOrEmpty(result))
                return result;
            else
            {

                _logger.LogWarning($"Resource {resourceKey} not found");

                if (!string.IsNullOrEmpty(defaultValue))
                {
                    result = defaultValue;
                }
                else
                {                
                    result = resourceKey;
                }

                return result;
            }
        }

        //    public virtual  TPropType GetLocalizedAsync<TEntity, TPropType>(TEntity entity, Expression<Func<TEntity, TPropType>> keySelector)
        //    where TEntity :class
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));

            
        //    var result = default(TPropType);
        //    var localizer = keySelector.Compile();
        //    result = localizer(entity);
        //    return result;
        //}


    }
}
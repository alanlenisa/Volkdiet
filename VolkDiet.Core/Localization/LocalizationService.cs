

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
       


        public LocalizationService(ILogger<LocalizationService> logger,
            ICacheManager cacheManager) {

            _logger = logger;
            _cacheManager = cacheManager;
        }

      

       

        protected virtual Dictionary<string, KeyValuePair<string, string>> ValuesToDict(IEnumerable<LocalizedValue> locales)
        {
          
            var dictionary = new Dictionary<string, KeyValuePair<string, string>>();
            foreach (var l in locales)
            {
                var name = l.Name.ToLowerInvariant();
                if (!dictionary.ContainsKey(name))
                    dictionary.Add(name, new KeyValuePair<string, string>(l.Language, l.Value));
            }

            return dictionary;
        }



        public virtual async Task<string> GetResourceAsync(string resourceKey)
        {
            var userLanguage = 0;//TODO: read user language or select default/first

            if (userLanguage >=0)
                return await GetResourceAsync(resourceKey, userLanguage);

            return "";
        }


        private String GetValue()
        {
            return "??";
        }
        
        public virtual async Task<string> GetResourceAsync(string resourceKey, int language,   string defaultValue = "")
        {
            var result = string.Empty;
            if (resourceKey == null)
                resourceKey = string.Empty;
            //?

            var key = _cacheManager.CreateKeyOnCache(COByNameCacheKey, language, resourceKey);
            var value = _cacheManager.Get(key,() =>GetValue());
            if (value != null)
                result = value;

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

            public virtual  TPropType GetLocalizedAsync<TEntity, TPropType>(TEntity entity, Expression<Func<TEntity, TPropType>> keySelector)
            where TEntity :class
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            
            var result = default(TPropType);
            var localizer = keySelector.Compile();
            result = localizer(entity);
            return result;
        }


    }
}
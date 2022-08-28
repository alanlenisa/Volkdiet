
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolkDiet.Core.Infrastructure;
using VolkDiet.Core.Localization;

namespace VolkDiet.WebCore.Mvc
{
    /// <summary>
    /// localization attribute for models
    /// </summary>
    public sealed class ResourceDisplayNameAttribute : DisplayNameAttribute
    {
       

        private string _value = "";
     
        public string Key { get; set; }
    

        public ResourceDisplayNameAttribute(string resourceKey) : base(resourceKey)
        {
            Key = resourceKey;
        }

   

   

        public override string DisplayName
        {
            get
            {
                ILocalizationService ls = EngineContext.Current.Resolve<ILocalizationService>();
                _value = ls.GetResourceAsync(Key).Result;
               
                return _value;

            }
        }

       
        public string Name => nameof(ResourceDisplayNameAttribute);

    }
}

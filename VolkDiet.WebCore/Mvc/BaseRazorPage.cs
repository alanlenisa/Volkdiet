using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolkDiet.Core.Infrastructure;
using VolkDiet.Core.Localization;

namespace VolkDiet.Core.Mvc
{
    public delegate TranslatedString Localizer(string text, params object[] args);
    public class TranslatedString : HtmlString
    {
        
        public TranslatedString(string localized) : base(localized)
        {
            Text = localized;
        }

        
        public string Text { get; }
    }




    public abstract class BaseRazorPage<TModel>:Microsoft.AspNetCore.Mvc.Razor.RazorPage<TModel>
    {
        private Localizer _localizer;
        private ILocalizationService _localizationService;
        //public BaseRazorPage( ILocalizationService localizationService)
        //{
        //    //_localizer = localizer;
        //    _localizationService = localizationService;
        //}


        /// <summary>
        /// function callable in razor pages for getting localized strings
        /// </summary>
        public Localizer Translate 
        {
            get {
                if (_localizationService == null)
                    _localizationService = EngineContext.Current.Resolve<ILocalizationService>();

                if (_localizer == null)
                {
                    _localizer = (txt, args) =>
                    {
                        var res = _localizationService.GetResourceAsync(txt).Result;

                        if (string.IsNullOrEmpty(res))
                        {
                            return new TranslatedString(res);
                        }
                        return new TranslatedString((args == null || args.Length == 0)
                            ? res
                            : string.Format(res, args));
                    };
                    
                 }
                return _localizer;
            }
        }
    }

    public abstract class BaseRazorPage : BaseRazorPage<dynamic> 
    {

    }
}

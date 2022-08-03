using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolkDiet.Core
{
    public  interface IWWWHelper
    {
        string GetPageUrl(bool queryString);
    }
    /// <summary>
    /// common utils in web environment
    /// </summary>
    public class WWWHelper:IWWWHelper           
    {   
        private readonly IHttpContextAccessor _httpContextAccessor;
        public WWWHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }

        protected virtual bool IsRequest()
        { 
            try
            {
                if (_httpContextAccessor?.HttpContext == null)
                    return false;

          
                if (_httpContextAccessor.HttpContext.Request == null)
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get url of current request
        /// </summary>
        /// <param name="useQueryString">if true include the query string</param>
        /// <returns></returns>
        public virtual string GetPageUrl(bool useQueryString)
        {

            if (!IsRequest())
                return "";

            var pageUrl = $"{_httpContextAccessor.HttpContext.Request.Path}";

            
            if (useQueryString)
                pageUrl = $"{pageUrl}{_httpContextAccessor.HttpContext.Request.QueryString}";

           

            return pageUrl;
        }
    }
}

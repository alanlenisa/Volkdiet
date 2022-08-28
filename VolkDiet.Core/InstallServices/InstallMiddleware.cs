using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolkDiet.Core.Data;

namespace VolkDiet.Core.InstallServices
{
    public class InstallMiddleware
    {
        private readonly RequestDelegate _next;



        public InstallMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IWWWHelper helper)
        {
            
            if (/*!DBSettings.IsDbInstalled()*/false)
            {
                string path = $"/setup/indexsetup";
                string url = helper.GetPageUrl(false);
                if (!url.StartsWith(path, StringComparison.InvariantCultureIgnoreCase))
                {
                    //redirect
                    context.Response.Redirect(path);
                    return;
                }
            }

            //next middleware in the pipeline
            await _next(context);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VolkDiet.Core.Data;

namespace VolkDiet.Controllers
{
    public class SetupModel 
    {
        public string newurl { get; set; }
        public string server { get; set; }
        public string database { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public bool trusted { get; set; }

        
        public ProviderType provider { get; set; }
        /// <summary>
        /// list of providers
        /// </summary>
        public List<SelectListItem> Providers { get; set; }

    }
    public class SetupController : Controller
    {
        public  IActionResult IndexSetup()
        {
            if (DBSettings.IsDbInstalled())
                return RedirectToRoute(WebDefaults.HOME_PAGE);

            var model = new SetupModel
            { 
                provider= ProviderType.MsSql
            };
            FillProviders(ref model);
            return View();
        }

        private void FillProviders(ref SetupModel model)
        {
            var dbtypes = DBSettings.GetAllProviders();
            model.Providers.AddRange(dbtypes.Select(
                s => new SelectListItem {
                    Value=s.Key.ToString(),
                    Text=s.Value
                })
            );
            
        }

        [HttpPost]
        public virtual async Task<IActionResult> IndexSetup(SetupModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                return View(new SetupModel { });
            }
            catch (Exception ex)
            { 
                //..
            }
            return View(model);
            

        }
    }
}

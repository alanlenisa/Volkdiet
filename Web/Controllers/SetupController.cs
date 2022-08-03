using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VolkDiet.Core.Data;
using VolkDiet.Models;

namespace VolkDiet.Controllers
{
    
    public class SetupController : Controller
    {
        /// <summary>
        /// this path is called when setting database 
        /// </summary>
        /// <returns></returns>
        public  IActionResult IndexSetup()
        {
            if (DBSettings.IsDbInstalled())
                return RedirectToRoute(WebDefaults.HOME_PAGE);

            var model = new SetupModel
            { 
                provider= ProviderType.MsSql
            };
            FillProviders(ref model);
            return View(model);
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
        /// <summary>
        /// this path is called when database setup  starts
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<IActionResult> IndexSetup(SetupModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                IDataProvider dataProvider;
                switch (model.provider)
                {
                    case ProviderType.MsSql:
                            dataProvider = new MsSqlDataProvider();
                        break;
                    case ProviderType.PgSql:
                            dataProvider = new PgSqlDataProvider();
                        break;
                    default:
                        throw new Exception("Wrong Db Type");

                };
                string connectionstring = dataProvider.MakeConnString(model.database, model.server, model.trusted, model.user, model.password);
                if (! await dataProvider.DbExistsAsync())
                    dataProvider.CreateDb();

                dataProvider.InitDb();

                return View(new SetupModel {newurl=WebDefaults.HOME_PAGE });
            }
            catch (Exception ex)
            {
                //..
                ModelState.AddModelError("", $"Setup failed {ex.Message}");
            }
            return View(model);
            

        }
    }
}

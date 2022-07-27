using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VolkDiet.Core.Caching;
using VolkDiet.Core.Localization;
using VolkDiet.Models;

namespace VolkDiet.Controllers
{
    /// <summary>
    /// TODO:remove on production, only for test
    /// </summary>
    public class CacheTestModel
    {
        [ ResourceDisplayName("testmodel.current")]
        public DateTime CurrentDateTime { get; set; }

        [ResourceDisplayName("testmodel.cached")]

        public DateTime CachedDateTime { get; set; }


    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICacheManager _cacheManager;

        public HomeController(ILogger<HomeController> logger,
                ICacheManager cacheManager)
        {
            _logger = logger;
            _cacheManager = cacheManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var key = _cacheManager.CreateKeyOnCache(new CachedObject("datetime.cached"));
            var value=_cacheManager.Get(key,() => DateTime.Now);
            CacheTestModel model = new CacheTestModel();
            model.CurrentDateTime=DateTime.Now;
            model.CachedDateTime = value;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
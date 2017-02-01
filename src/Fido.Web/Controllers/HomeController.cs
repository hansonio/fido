using Fido.Web.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fido.Web.Controllers
{
    [Route("/")]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class HomeController: Controller
    {
        private AppSettings _appSettings;

        public HomeController(IOptions<AppSettings> appSettingsAccessor)
        {
            _appSettings = appSettingsAccessor.Value;
        }

        public IActionResult Index()
        {
            ViewBag.Title = _appSettings.Title;
            return View();
        }
    }
}

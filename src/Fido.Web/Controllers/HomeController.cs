using Fido.Web.Configuration;
using Fido.Web.Data;
using Fido.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;

namespace Fido.Web.Controllers
{
    [Route("/")]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class HomeController: Controller
    {
        private AppSettings _appSettings;
        private ApplicationDataContext _dataContext;

        public HomeController(IOptions<AppSettings> appSettingsAccessor, ApplicationDataContext dataContext)
        {
            _appSettings = appSettingsAccessor.Value;
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var pets = _dataContext.Pets.ToList<Pet>();

            ViewBag.Title = _appSettings.Title;
            return View();
        }
    }
}

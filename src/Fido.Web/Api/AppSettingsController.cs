using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Fido.Web.Configuration;

namespace Fido.Web.Api
{
    [Route("/api/settings")]
    public class AppSettingsController: Controller
    {
        private readonly AppSettings _appSettings;

        public AppSettingsController(IOptions<AppSettings> _appSettingsAccessor)
        {
            _appSettings = _appSettingsAccessor.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_appSettings);
        }

    }
}

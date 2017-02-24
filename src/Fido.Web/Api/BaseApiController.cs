using Fido.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fido.Web.Api
{
    [Authorize]
    [Route("/api/[controller]/")]
    public abstract class BaseApiController: Controller
    {
        protected ApplicationDataContext DataContext { get; set; }

        public BaseApiController(ApplicationDataContext dataContext)
        {
            DataContext = dataContext;
        }
    }
}

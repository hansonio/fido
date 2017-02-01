using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fido.Web.Api
{
    [Route("/api/[controller]/")]
    public abstract class BaseApiController: Controller
    {
    }
}

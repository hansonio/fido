using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fido.Web.Models
{
    public class ApplicationUser: IdentityUser<Guid>
    {
    }
}

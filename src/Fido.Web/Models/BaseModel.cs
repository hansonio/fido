using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fido.Web.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }

        public DateTime Timestamp { get; set; }
    }
}

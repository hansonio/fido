using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fido.Web.Models
{
    public class Walk: BaseModel
    {
        public Guid PetId { get; set; }
        
        public DateTime? WalkDateTime { get; set; }

        public int? DurationInMinutes { get; set; }

        public String WalkType { get; set; }

        public String Comments { get; set; }
    }
}

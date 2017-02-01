using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fido.Web.Models
{
    public class Pet: BaseModel
    {
        public Guid CustomerId { get; set; }

        public String PetType { get; set; }

        public String Name { get; set; }

        public String Breed { get; set; }

        public int? Age { get; set; }

        public String WalkTimes { get; set; }

        public String Notes { get; set; }

        public Decimal? CostPerWalk { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fido.Web.Models
{
    public class Pet: BaseModel
    {
        [Required]
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required]
        [MaxLength(100)]
        public String PetType { get; set; }

        [Required]
        [MaxLength(100)]
        public String Name { get; set; }
        
        [MaxLength(100)]
        public String Breed { get; set; }
        
        public int? Age { get; set; }

        [MaxLength(500)]
        public String WalkTimes { get; set; }

        [MaxLength(int.MaxValue)]
        public String Notes { get; set; }

        public Decimal? CostPerWalk { get; set; }

        public List<Walk> Walks { get; set; }
    }
}

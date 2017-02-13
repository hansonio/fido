using System;
using System.ComponentModel.DataAnnotations;

namespace Fido.Web.Models
{
    public class Walk : BaseModel
    {
        public Guid PetId { get; set; }

        public Pet Pet{get;set;}
        
        public DateTime? WalkDateTime { get; set; }

        public int? DurationInMinutes { get; set; }

        [Required]
        [MaxLength(100)]
        public String WalkType { get; set; }

        [MaxLength(int.MaxValue)]
        public String Comments { get; set; }
    }
}

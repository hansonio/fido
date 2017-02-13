using System;
using System.ComponentModel.DataAnnotations;

namespace Fido.Web.Models
{
    public abstract class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        
        public DateTime Timestamp { get; set; }
    }
}

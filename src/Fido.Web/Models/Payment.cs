using System;
using System.ComponentModel.DataAnnotations;

namespace Fido.Web.Models
{
    /// <summary>
    /// A payment from one of our customers
    /// </summary>
    public class Payment: BaseModel
    {
        [Required]
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public DateTime PaymentDateTime { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [MaxLength(500)]
        public String Memo { get; set; }

        [MaxLength(200)]
        public String ExternalId { get; set; }
    }
}

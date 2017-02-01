using System;
namespace Fido.Web.Models
{
    public class Payment: BaseModel
    {
        public Guid CustomerId { get; set; }

        public DateTime PaymentDateTime { get; set; }

        public decimal Amount { get; set; }

        public String Memo { get; set; }

        public String ExternalId { get; set; }
    }
}

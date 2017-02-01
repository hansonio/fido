using System;

namespace Fido.Web.Models
{
    public class Customer: BaseModel
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }
        public String Notes { get; set; }
        public bool NotifyAdHoc { get; set; }
    }
}

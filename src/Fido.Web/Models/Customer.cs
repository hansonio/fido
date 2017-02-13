using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fido.Web.Models
{
    /// <summary>
    /// Domain class representing a single customer
    /// </summary>
    public class Customer: BaseModel
    {
        [Required]
        [MaxLength(125)]
        public String Name { get; set; }

        [MaxLength(254)]
        public String Email { get; set; }

        [MaxLength(20)]
        public String Phone { get; set; }

        [MaxLength(200)]
        public String Address { get; set; }

        [MaxLength(200)]
        public String City { get; set; }

        [MaxLength(55)]
        public String State { get; set; }

        [MaxLength(15)]
        public String Zip { get; set; }

        [MaxLength(int.MaxValue)]
        public String Notes { get; set; }

        public bool NotifyAdHoc { get; set; }

        public bool InActive { get; set; }

        public List<Pet> Pets { get; set; }

        public List<Payment> Payments { get; set; }
    }
}

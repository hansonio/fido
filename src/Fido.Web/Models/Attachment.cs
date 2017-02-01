using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fido.Web.Models
{
    public class Attachment: BaseModel
    {
        public Guid EntityId { get; set; }

        public String Name { get; set; }

        public String MimeType { get; set; }

        public int? Size { get; set; }

        public byte[] Data { get; set; }
    }
}

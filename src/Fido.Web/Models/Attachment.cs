using System;
using System.ComponentModel.DataAnnotations;

namespace Fido.Web.Models
{
    /// <summary>
    /// Represents and picture of a dog on one of our walks
    /// </summary>
    public class Attachment: BaseModel
    {
        /// <summary>
        /// A general id that let's us associate attachments to customers, pets or walks
        /// </summary>
        [Required]
        public Guid EntityId { get; set; }

        [Required]
        [MaxLength(250)]
        public String Name { get; set; }

        [Required]
        [MaxLength(55)]
        public String MimeType { get; set; }
        
        public int? Size { get; set; }

        [Required]
        public byte[] Data { get; set; }
    }
}

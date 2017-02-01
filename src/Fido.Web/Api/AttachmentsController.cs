using System;
using Fido.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fido.Web.Api
{
    /// <summary>
    /// Manage attachments and images
    /// </summary>
    public class AttachmentsController: BaseApiController
    {
        /// <summary>
        /// Get Attachment contents
        /// </summary>
        /// <remarks>
        /// Can be called with or without the attachment file name even though Swagger indicates that it is required.
        /// 
        ///     GET /api/customers/41E864E1-9BC9-440A-8209-FF42D29445C4/attachments/D298F1A4-A88D-4FEC-B966-AD062EEDFE78
        ///     GET /api/customers/41E864E1-9BC9-440A-8209-FF42D29445C4/attachments/D298F1A4-A88D-4FEC-B966-AD062EEDFE78/myimpage.png
        ///     
        /// </remarks>
        /// <param name="id">Id of the attachment</param>
        /// <param name="entityType">Type of collection the owning entity belongs to</param>
        /// <param name="entityId">Id of owning object</param>
        /// <param name="name">File name of the image</param>
        /// <returns>The contents of the attachment</returns>
        /// <response code="200">Returns contents of the attachment</response>
        /// <response code="404">If the id is not found</response>
        [HttpGet("/api/{entityType}/{entityId}/attachments/{id}/{name?}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Get(Guid id, string entityType, Guid entityId, [FromRoute]string name = null)
        {
            return Ok(new { id, entityId, entityType, name });
        }

        /// <summary>
        /// Get Attachment Metadata
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The attachment enitity</returns>
        /// <response code="200">Returns contents of the attachment</response>
        /// <response code="404">If the id is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Attachment), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetData(Guid id)
        {
            var attachment = new Attachment() { Id = Guid.NewGuid(), Name = "TestImage.jpg" };

            return Ok(attachment);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }
    }
}

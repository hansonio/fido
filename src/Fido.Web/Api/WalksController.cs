using Fido.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fido.Web.Api
{
    public class WalksController: BaseApiController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Walk), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(Guid id)
        {
            var Walk = new Walk() { Id = id, WalkDateTime = DateTime.UtcNow.AddDays(-1) , WalkType="Run"};

            return Ok(Walk);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<Walk>), 200)]
        public IActionResult Get()
        {
            var Walks = new List<Walk>()
            {
                new Walk(){Id = Guid.NewGuid(), WalkDateTime = DateTime.UtcNow.AddDays(-1)},
                new Walk(){Id = Guid.NewGuid(), WalkDateTime = DateTime.UtcNow}
            };

            return Ok(Walks);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Walk), 201)]
        public IActionResult Walk([FromBody, Required]Walk model)
        {
            model.Id = Guid.NewGuid();
            model.Timestamp = DateTime.UtcNow;

            return Created($"/api/Walks/{model.Id}", model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public IActionResult Put(Guid id, [FromBody, Required]Walk model)
        {
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }
    }
}

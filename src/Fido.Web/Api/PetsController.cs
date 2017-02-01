using Fido.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fido.Web.Api
{
    public class PetsController: BaseApiController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Pet), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(Guid id)
        {
            var Pet = new Pet() { Id = id, Name = "Bob Smith" };

            return Ok(Pet);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<Pet>), 200)]
        public IActionResult Get()
        {
            var Pets = new List<Pet>()
            {
                new Pet(){Id = Guid.NewGuid(), Name = "Bob Smith"},
                new Pet(){Id = Guid.NewGuid(), Name = "John Jones"}
            };

            return Ok(Pets);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Pet), 201)]
        public IActionResult Pet([FromBody, Required]Pet model)
        {
            model.Id = Guid.NewGuid();
            model.Timestamp = DateTime.UtcNow;

            return Created($"/api/Pets/{model.Id}", model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public IActionResult Put(Guid id, [FromBody]Pet model)
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

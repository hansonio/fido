using Fido.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fido.Web.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Fido.Web.Api
{
    public class WalksController: BaseApiController
    {
        public WalksController(ApplicationDataContext dataContext) : base(dataContext)
        {
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Walk), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(Guid id)
        {
            var walk = await DataContext.Walks.SingleOrDefaultAsync(x => x.Id == id);

            if (walk == null)
            {
                return NotFound();
            }

            return Ok(walk);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<Walk>), 200)]
        public async Task<IActionResult> GetWalks()
        {
            return Ok(DataContext.Walks);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Walk), 201)]
        public async Task<IActionResult> Post([FromBody, Required]Walk model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            model.Timestamp = DateTime.UtcNow;

            DataContext.Walks.Add(model);
            await DataContext.SaveChangesAsync();

            return Created($"/api/walks/{model.Id}", model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Put(Guid id, [FromBody, Required]Walk model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var walk = await DataContext.Walks.SingleOrDefaultAsync(x => x.Id == id);

            if (walk == null)
            {
                return NotFound();
            }

            walk.Comments = walk.Comments;
            walk.DurationInMinutes = walk.DurationInMinutes;
            walk.WalkDateTime = walk.WalkDateTime;
            walk.WalkType = walk.WalkType;
            walk.Timestamp = DateTime.UtcNow;

            DataContext.Walks.Update(walk);
            await DataContext.SaveChangesAsync();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var walk = await DataContext.Walks.SingleOrDefaultAsync(x => x.Id == id);
            if (walk == null)
            {
                return NotFound();
            }

            DataContext.Walks.Remove(walk);
            await DataContext.SaveChangesAsync();

            return Ok();
        }
    }
}

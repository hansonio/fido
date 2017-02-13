using Fido.Web.Data;
using Fido.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fido.Web.Api
{
    public class PetsController : BaseApiController
    {
        public PetsController(ApplicationDataContext dataContext) : base(dataContext)
        {
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Pet), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(Guid id)
        {
            var pet = await DataContext.Pets.SingleOrDefaultAsync(x => x.Id == id);

            if (pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
        }

        [HttpGet("/api/customers/{id}/pets")]
        [ProducesResponseType(typeof(IList<Pet>), 200)]
        public async Task<IActionResult> GetCustomerPets([FromRoute] Guid id)
        {
            var pets = await DataContext.Pets.Where(x => x.CustomerId == id).ToListAsync();
            return Ok(pets);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Pet), 201)]
        public async Task<IActionResult> Post([FromBody, Required]Pet model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            model.Timestamp = DateTime.UtcNow;

            DataContext.Pets.Add(model);
            await DataContext.SaveChangesAsync();

            return Created($"/api/pets/{model.Id}", model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Put(Guid id, [FromBody]Pet model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var pet = await DataContext.Pets.SingleOrDefaultAsync(x => x.Id == id);

            if (pet == null)
            {
                return NotFound();
            }

            pet.Age = model.Age;
            pet.Breed = model.Breed;
            pet.CostPerWalk = model.CostPerWalk;
            pet.Name = model.Name;
            pet.Notes = model.Notes;
            pet.PetType = model.PetType;
            pet.WalkTimes = model.WalkTimes;

            pet.Timestamp = DateTime.UtcNow;

            DataContext.Pets.Update(pet);
            await DataContext.SaveChangesAsync();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var pet = await DataContext.Pets.SingleOrDefaultAsync(x => x.Id == id);
            if (pet == null)
            {
                return NotFound();
            }

            DataContext.Pets.Remove(pet);
            await DataContext.SaveChangesAsync();

            return Ok();
        }
    }
}

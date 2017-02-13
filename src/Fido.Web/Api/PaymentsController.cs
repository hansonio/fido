using Fido.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fido.Web.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fido.Web.Api
{
    public class PaymentsController: BaseApiController
    {
        public PaymentsController(ApplicationDataContext dataContext) : base(dataContext)
        {
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Payment), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get([FromRoute]Guid id)
        {
            var payments = await DataContext.Payments.SingleOrDefaultAsync(x => x.Id == id);

            if (payments == null)
            {
                return NotFound();
            }

            return Ok(payments);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<Payment>), 200)]
        public async Task<IActionResult> Get()
        {
            var payments = await DataContext.Payments.ToAsyncEnumerable().ToList();
            return Ok(payments);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Payment), 201)]
        public async Task<IActionResult> Post([FromBody, Required]Payment model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            model.Timestamp = DateTime.UtcNow;

            DataContext.Payments.Add(model);
            await DataContext.SaveChangesAsync();

            return Created($"/api/payments/{model.Id}", model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Put(Guid id, [FromBody, Required]Payment model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(id != model.Id)
            {
                return BadRequest();
            }

            DataContext.Entry(model).State = EntityState.Modified;
            await DataContext.SaveChangesAsync();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var payment = await DataContext.Payments.SingleOrDefaultAsync(x => x.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            DataContext.Payments.Remove(payment);
            await DataContext.SaveChangesAsync();

            return Ok();
        }
    }
}

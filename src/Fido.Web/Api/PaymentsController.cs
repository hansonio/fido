using Fido.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fido.Web.Api
{
    public class PaymentsController: BaseApiController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Payment), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(Guid id)
        {
            var Payment = new Payment() { Id = id, PaymentDateTime = DateTime.UtcNow.AddDays(-1) ,Amount= 100};

            return Ok(Payment);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<Payment>), 200)]
        public IActionResult Get()
        {
            var Payments = new List<Payment>()
            {
                new Payment(){Id = Guid.NewGuid(), PaymentDateTime = DateTime.UtcNow.AddDays(-1)},
                new Payment(){Id = Guid.NewGuid(), PaymentDateTime = DateTime.UtcNow}
            };

            return Ok(Payments);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Payment), 201)]
        public IActionResult Post([FromBody, Required]Payment model)
        {
            model.Id = Guid.NewGuid();
            model.Timestamp = DateTime.UtcNow;

            return Created($"/api/Payments/{model.Id}", model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public IActionResult Put(Guid id, [FromBody, Required]Payment model)
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

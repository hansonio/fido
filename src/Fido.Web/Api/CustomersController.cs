using Fido.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fido.Web.Api
{
    /// <summary>
    /// Manage Customers
    /// </summary>
    public class CustomersController: BaseApiController
    {
        /// <summary>
        /// Retrieve a single customer
        /// </summary>
        /// <param name="id">Id of the customer</param>
        /// <returns>The customer object</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Customer), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(Guid id)
        {
            var customer = new Customer() { Id = id, Name = "Bob Smith" };

            return Ok(customer);
        }

        /// <summary>
        /// Retrieves a list of Customers
        /// </summary>
        /// <returns>List of customers</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IList<Customer>), 200)]
        public IActionResult Get()
        {
            var customers = new List<Customer>()
            {
                new Customer(){Id = Guid.NewGuid(), Name = "Bob Smith"},
                new Customer(){Id = Guid.NewGuid(), Name = "John Jones"}
            };

            return Ok(customers);
        }

        /// <summary>
        /// Adds a new customer
        /// </summary>
        /// <param name="model">Customer object to add</param>
        /// <returns>The new customer object</returns>
        /// <response code="200">Returns the new customer</response>
        /// <response code="403">The passed in model is invalid.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Customer), 201)]
        [ProducesResponseType(403)]
        public IActionResult Post([FromBody, Required]Customer model)
        {
            model.Id = Guid.NewGuid();
            model.Timestamp = DateTime.UtcNow;

            return Created($"/api/customers/{model.Id}", model);
        }

        /// <summary>
        /// Update an existing Customer
        /// </summary>
        /// <param name="Id">Customer Id</param>
        /// <param name="model">New values for customer object</param>
        /// <returns>The updated customer</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public IActionResult Put(Guid Id, [FromBody, Required]Customer model)
        {
            return Ok(model);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Customer), 200)]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }
    }
}

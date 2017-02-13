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
    /// <summary>
    /// Manage Customers
    /// </summary>
    public class CustomersController: BaseApiController
    {
        public CustomersController(ApplicationDataContext dataContext) : base(dataContext)
        {
        }

        /// <summary>
        /// Retrieve a single customer
        /// </summary>
        /// <param name="id">Id of the customer</param>
        /// <returns>The customer object</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Customer), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var customer = await DataContext.Customers.SingleOrDefaultAsync(x => x.Id == id);

            if(customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        /// <summary>
        /// Retrieves a list of Customers
        /// </summary>
        /// <returns>List of customers</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IList<Customer>), 200)]
        public async Task<IActionResult> Get()
        {
            var customers = await DataContext.Customers.ToAsyncEnumerable().ToList();

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
        public async Task<IActionResult> Post([FromBody, Required]Customer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            model.Timestamp = DateTime.UtcNow;

            DataContext.Customers.Add(model);
            await DataContext.SaveChangesAsync();

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
        public async Task<IActionResult> Put([FromRoute]Guid id, [FromBody, Required]Customer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await DataContext.Customers.SingleOrDefaultAsync(x => x.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.Name = model.Name;
            customer.Email = model.Email;
            customer.Phone = model.Phone;
            customer.Address = model.Address;
            customer.City = model.City;
            customer.State = model.State;
            customer.Zip = model.Zip;
            customer.Name = model.Notes;
            customer.NotifyAdHoc = model.NotifyAdHoc;

            customer.Timestamp = DateTime.UtcNow;

            DataContext.Customers.Update(customer);
            await DataContext.SaveChangesAsync();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Customer), 200)]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var customer = await DataContext.Customers.SingleOrDefaultAsync(x => x.Id == id);
            if(customer == null)
            {
                return NotFound();
            }

            DataContext.Customers.Remove(customer);
            await DataContext.SaveChangesAsync();

            return Ok();
        }
    }
}

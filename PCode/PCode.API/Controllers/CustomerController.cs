using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PCode.DTO;
using PCode.Service;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PCode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll().ConfigureAwait(false));
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.Get(id).ConfigureAwait(false));
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerDTO customer)
        {
            return Ok(await _service.Add(customer).ConfigureAwait(false));
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerDTO customer)
        {
            customer.Id = id;
            return Ok(await _service.Update(customer).ConfigureAwait(false));
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] CustomerDTO customer)
        {
            customer.Id = id;
            return Ok(await _service.Delete(customer).ConfigureAwait(false));
        }
    }
}

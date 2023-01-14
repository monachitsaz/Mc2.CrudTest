using Mc2.CrudTest.Presentation.Server.Application.Services;
using Mc2.CrudTest.Shared.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Task.FromResult(_service.GetCustomerList());
            //var result = _service.GetCustomerList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _service.GetCustomerData(id);
            if (customer != null)
            {
                return Ok(customer);
            }
            return NotFound();
        }



        [HttpPost]
        public IActionResult Create(Customer customer)
        {

            var result = _service.AddCustomer(customer);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            _service.UpdateCustomer(customer);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingItem = _service.GetCustomerData(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            else
            {
                _service.DeleteCustomer(id);
                return Ok();
            }

        }

    }
}

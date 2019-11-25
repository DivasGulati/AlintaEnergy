using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlintaEnergy.Application.Abstractions.Services;
using AlintaEnergy.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AlintaEnergy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<CustomerDto> Get(int id)
        {
            try
            {
                var retVal = _customerService.GetCustomer(id);
                return Ok(retVal);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }           
         
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] CustomerDto customer)
        {
            try
            {
               var retVal =  _customerService.CreateCustomer(customer);
                return Ok(retVal);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex);
            }
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

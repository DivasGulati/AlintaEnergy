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

        [HttpGet()]
        public ActionResult<CustomerDto> GetAll()
        {
            try
            {
                var retVal = _customerService.GetAllCustomer();
                return Ok(retVal);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }


        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody] CustomerDto customer)
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




        // POST api/values
        [HttpPost("search")]
        public IActionResult Search(string searchText)
        {
            try
            {
                var retVal = _customerService.GetCustomerBySearchText(searchText);
                return Ok(retVal);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        // PUT api/values
        [HttpPut()]
        public void Put([FromBody] CustomerDto newCustomerData)
        {
            var h = _customerService.Update(newCustomerData);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var retVal = _customerService.RemoveCustomer(id);
                return Ok(retVal);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}

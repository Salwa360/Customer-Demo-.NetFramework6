using BasicDataOfCustomers.API.DTOs;
using BasicDataOfCustomers.Infrastructure.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BasicData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServiceAsync _customerService;
        public CustomerController(ICustomerServiceAsync customerService)
        {
            _customerService = customerService;
        }
        [HttpPost("GetCustomers")]
        public async Task<IActionResult> GetAllCustomersAsync(FilteringCustomersDto dto)
        {
            return Ok(await _customerService.GetAllCustomersAsync(dto));
        }
        [HttpGet("GetCustomer/{id}")]
        public async Task<IActionResult> GetCustomerByIdAsync(int id)
        {
            if (id == 0)
                return BadRequest("Invalid Customer Id");
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound("Invalid Customer in Database");
            return Ok(customer);
        }
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomerAsync(CustomerDto customerDto)
        {
            return Ok(await _customerService.AddNewCustomerAsync(customerDto));
        }
        [HttpPut("EditCustomer")]
        public async Task<IActionResult> EditCustomerAsync(CustomerDto customerDto)
        {
            return Ok(await _customerService.EditCustomerAsync(customerDto));
        }
        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            if (id == 0)
                return BadRequest("invalid Customer id");
            var customer = await _customerService.DeleteCustomerByIdAsync(id);
            if (!customer)
                return BadRequest("invalid Customer");
            return Ok(customer);
        }
    }
}

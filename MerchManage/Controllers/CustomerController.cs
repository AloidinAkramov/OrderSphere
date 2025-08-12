using MerchManage.Models;
using MerchManage.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MerchManage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostMessageAsync(Customer customer)
        {
            await this.customerService.AddCustomerAsync(customer);

            return Ok(customer);
        }



        [HttpGet("{customerId}")]
        public async Task<ActionResult<Customer>> GetMessageByIdAsync(Guid customerId)
        {
            var customer = await this.customerService.RetrieveCustomerByIdAsync(customerId);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpDelete("{customerId}")]
        public async Task<ActionResult<Customer>> DeleteMessageByIdAsync(Guid customerId)
        {
            var customer = await this.customerService.RemoveCustomerByIdAsync(customerId);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}

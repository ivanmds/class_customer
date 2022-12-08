using Customer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private static List<CustomerEntity> _customers = new List<CustomerEntity>();

        [HttpGet]
        public IEnumerable<CustomerEntity> Get()
        {
            return _customers;
        }


        [HttpPost]
        public CustomerEntity Post(CustomerEntity customer)
        {
            _customers.Add(customer);
            return customer;
        }

    }
}

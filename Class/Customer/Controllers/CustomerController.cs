using Customer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private static List<CustomerEntity> database = new List<CustomerEntity>();

        [HttpGet]
        public IEnumerable<CustomerEntity> Get()
        {
            return database;
        }

        [HttpGet("{id:guid}")]
        public CustomerEntity Get(Guid id)
        {
            return database.Find(p => p.Id == id);
        }


        [HttpPost]
        public IActionResult Post(CustomerEntity customer)
        {
            var customerFound = database.Find(item => item.Document == customer.Document);

            if(customerFound != null)
            {
                return BadRequest($"The document informed {customer.Document} already in used.");
            }

            if (customer.Name.Length < 6)
            {
                return BadRequest($"The customer name should be greater than 5 caracters.");
            }

            customer.SetId(Guid.NewGuid());
            database.Add(customer);
            return Ok(customer);
        }


        [HttpPut("{id:guid}")]
        public IActionResult Put(Guid id, [FromBody] CustomerEntity customer)
        {
            var customerFound = database.Find(p => p.Id == id);

            if(customerFound == null)
            {
                return NotFound($"The customer with id {id} not found.");
            }

            database.Remove(customerFound);
            customer.SetId(id);
            database.Add(customer);

            return Ok(customerFound);
        }

    }
}

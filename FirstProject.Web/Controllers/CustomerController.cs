using AutoMapper;
using FirstProject.Web.Dto.Create;
using FirstProject.Web.Dto.Entites;
using FirstProject.Web.Dto.Update;
using FirstProject.Web.Extention;
using FirstProject.Web.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly restaurantdbContext _db;
        private readonly IMapper _mapper;
        public CustomerController(restaurantdbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        // GET: api/<RestaurantController>
        [HttpGet]
        public IActionResult GetCustomer()
        {
            var AllResturant = _db.Customers.ToList();
            return Ok(AllResturant);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{CustomerId:int}", Name = "GetCustomer")]
        public IActionResult GetCustomer(int customerId)
        {
            var CustomerId  = _db.Customers.FirstOrDefault(x => x.Id == customerId);
            if (CustomerId == null) return NotFound();
            return Ok(CustomerId);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomersDto createCustomerDto)
        {
            if (createCustomerDto == null) return BadRequest(ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            capitalize.FirstCharToUpper(createCustomerDto.FirstName);
            capitalize.FirstCharToUpper(createCustomerDto.LastName);

            var CustomerObj = _mapper.Map<Customer>(createCustomerDto);
            _db.Customers.Add(CustomerObj);
            _db.SaveChanges();
            return Ok(CustomerObj);
        }

        // PUT api/<CustomerController>/5
        [HttpPatch(Name = "UpdateCustomer")]
        public IActionResult UpdateCustomer([FromBody] UpdateCustomersDto customerDto)
        {
            var CustomerId = _db.Customers.FirstOrDefault(x => x.Id == customerDto.Id);
            if (CustomerId == null) return BadRequest(ModelState);

            var CustomerObj = _mapper.Map(customerDto, CustomerId);

            _db.Customers.Update(CustomerObj);
            _db.SaveChanges();
            return Ok(CustomerObj);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete]
        public IActionResult DeleteCustomer(int CustomerId)
        {
            var trailObj = _db.Customers.FirstOrDefault(x =>x.Id == CustomerId);
            if (trailObj == null) return NotFound();
            _db.Customers.Remove(trailObj);
            _db.SaveChanges();
            return Ok();
        }
     
    }
}

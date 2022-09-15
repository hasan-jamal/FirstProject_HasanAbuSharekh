using AutoMapper;
using FirstProject.Web.Dto.Create;
using FirstProject.Web.Dto.Update;
using FirstProject.Web.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly restaurantdbContext _db;
        private readonly IMapper _mapper;
      
        public OrdersController(restaurantdbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
         
        }
        // GET: api/<RestaurantController>
        [HttpGet]
        public IActionResult GetOrders()
        {
            var AllOrders = _db.RestaurantMenuCustomers.ToList();
            return Ok(AllOrders);
        }
        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateRestaurantMenuCustomerDto OrderDto)
        {  
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            if (isAvailable(OrderDto.RestaurantMenuId.Value))
            {
                var restaurantObj = _mapper.Map<RestaurantMenuCustomer>(OrderDto);
                _db.RestaurantMenuCustomers.Add(restaurantObj);
                _db.SaveChanges();
                return Ok();
            }
          return NotFound();
        }

        // PUT api/<RestaurantController>/5
        [HttpPatch( Name = "UpdateOrder")]
        public IActionResult UpdateOrder([FromBody] UpdateRestaurantMenuCustomerDto OrderDto)
        {
            var orderId = _db.RestaurantMenus.FirstOrDefault(x => x.Id == OrderDto.Id);
            if (orderId == null) return BadRequest(ModelState);

            var OrderObj = _mapper.Map(OrderDto, orderId);

            _db.RestaurantMenus.Update(OrderObj);
            _db.SaveChanges();
            return Ok(OrderObj);
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete]
        public IActionResult DeleteOrder(int OrderId)
        {
            var trailObj = _db.RestaurantMenuCustomers.FirstOrDefault(x => x.Id == OrderId);
            if (trailObj == null) return NotFound();
            _db.RestaurantMenuCustomers.Remove(trailObj);
            _db.SaveChanges();
            return Ok();
        }
        [HttpGet("resturantMenuId")]
        public bool isAvailable(int resturantMenuId)
        {
            var resturantObj = _db.RestaurantMenus.FirstOrDefault(x => x.Id == resturantMenuId);
            if(resturantObj == null) return false;

            resturantObj.Id = resturantMenuId;
            if (resturantMenuId > 0) return true;
            return false;
        }

      

    }
}

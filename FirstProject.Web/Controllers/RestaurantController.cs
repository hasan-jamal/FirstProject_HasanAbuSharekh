using AutoMapper;
using FirstProject.Web.Dto.Create;
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
    public class RestaurantController : ControllerBase
    {
        private readonly restaurantdbContext _db;
        private readonly IMapper _mapper;
        public RestaurantController(restaurantdbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // GET: api/<RestaurantController>
        [HttpGet]
        public IActionResult GetRestaurant()
        {
            // testc 
            _db.IgonreFilter = true;

            //test 
            ///coment 
            var AllResturant = _db.Restaurants.ToList();
            return Ok(AllResturant);
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{RestaurantId:int}", Name = "GetRestaurant")]
        public IActionResult GetRestaurant(int RestaurantId)
        {
            var restaurantId  = _db.Restaurants.FirstOrDefault(x => x.Id == RestaurantId);
            if (restaurantId == null) return NotFound();
            return Ok(restaurantId);
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public IActionResult CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
        {
            if (createRestaurantDto == null) return BadRequest(ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            capitalize.FirstCharToUpper(createRestaurantDto.Name);
             var restaurantObj = _mapper.Map<Restaurant>(createRestaurantDto);
            _db.Restaurants.Add(restaurantObj);
            _db.SaveChanges();
            return Ok(restaurantObj);
        }

        // PUT api/<RestaurantController>/5
        [HttpPatch(Name = "UpdateRestaurant")]
        public IActionResult UpdateRestaurant([FromBody] UpdateRestaurantDto RestaurantDto)
        {
            var restaurantId = _db.Restaurants.FirstOrDefault(x => x.Id == RestaurantDto.Id);
            if (restaurantId == null) return BadRequest(ModelState);

            var RestaurantObj = _mapper.Map(RestaurantDto, restaurantId);

            _db.Restaurants.Update(RestaurantObj);
            _db.SaveChanges();
            return Ok(RestaurantObj);
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete]
        public IActionResult DeleteRestaurant(int RestaurantId)
        {
            var trailObj = _db.Restaurants.FirstOrDefault(x =>x.Id == RestaurantId);
            if (trailObj == null) return NotFound();
            _db.Restaurants.Remove(trailObj);
            _db.SaveChanges();
            return Ok();
        }
     
    }
}

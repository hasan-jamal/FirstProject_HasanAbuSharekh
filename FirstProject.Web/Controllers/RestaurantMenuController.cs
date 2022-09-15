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
    public class RestaurantMenuController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly restaurantdbContext _db;
        public RestaurantMenuController(IMapper mapper, restaurantdbContext db)
        {
            _mapper = mapper;
            _db = db;
        }
        // GET: api/<RestaurantMenuController>
        [HttpGet]
        public IActionResult GetRestaurantMenu()
        {
            var AllResturant = _db.RestaurantMenus.ToList();
            return Ok(AllResturant);
        }

        // GET api/<RestaurantMenuController>/5
        [HttpGet("{RestaurantMenuId:int}", Name = "GetRestaurantMenu")]
        public IActionResult GetRestaurantMenu(int RestaurantMenuId)
        {
            var restaurantId = _db.RestaurantMenus.FirstOrDefault(x => x.Id == RestaurantMenuId);
            if (restaurantId == null) return NotFound();
            return Ok(restaurantId);
        }

        // POST api/<RestaurantMenuController>
        [HttpPost]
        public IActionResult CreateRestaurantMenu([FromBody] CreateRestaurantMenuDto createRestaurantMenusDto)
        {
            if (createRestaurantMenusDto == null) return BadRequest(ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            capitalize.FirstCharToUpper(createRestaurantMenusDto.MealName);
            var restaurantMenuObj = _mapper.Map<RestaurantMenu>(createRestaurantMenusDto);
            _db.RestaurantMenus.Add(restaurantMenuObj);
            _db.SaveChanges();
            return Ok(restaurantMenuObj);
        }

        //PUT api/<RestaurantMenuController>/5
        [HttpPatch( Name = "UpdateRestaurantMenu")]
        public IActionResult UpdateRestaurantMenu([FromBody] UpdateRestaurantMenuDto RestaurantMenuDto)
        {
            var restaurantId = _db.RestaurantMenus.FirstOrDefault(x => x.Id == RestaurantMenuDto.Id);
            if (restaurantId == null ) return BadRequest(ModelState);

            var RestaurantObj = _mapper.Map( RestaurantMenuDto ,restaurantId );

            _db.RestaurantMenus.Update(RestaurantObj);
            _db.SaveChanges();
            return Ok(RestaurantObj);
        }

        // DELETE api/<RestaurantMenuController>/5
        [HttpDelete]
        public IActionResult DeleteRestaurantMenu(int RestaurantMenuId)
        {
            var trailObj = _db.RestaurantMenus.FirstOrDefault(x => x.Id == RestaurantMenuId);
            if (trailObj == null) return NotFound();
            _db.RestaurantMenus.Remove(trailObj);
            _db.SaveChanges();
            return Ok();
        }
        [HttpGet("resturantMenuId")]
        public bool isAvailable(int resturantMenuId)
        {
            var resturantObj = _db.RestaurantMenus.FirstOrDefault(x => x.Id == resturantMenuId);
            resturantObj.Id = resturantMenuId;
            if (resturantMenuId > 0) return true;
            return false;
        }
    }
}

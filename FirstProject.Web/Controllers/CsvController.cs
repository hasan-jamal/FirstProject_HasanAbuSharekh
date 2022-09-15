using FirstProject.Web.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;

namespace FirstProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvController : ControllerBase
    {
        private readonly restaurantdbContext _db;
        public CsvController(restaurantdbContext db)
        {
            _db = db;

        }
        //GET: api/<CsvController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _db.OrdersViews.ToList();
            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult Csv()
        {
            var builder = new StringBuilder();
            builder.AppendLine("RestaurantName,NumberOfOrderedCustomer,PriceInNis,ProfitInUsd,TheBestSellingMeal,MostPurchasedCustomer");
            var result = _db.OrdersViews.ToList();

            foreach (var item in result)
            {
                builder.AppendLine
                    ($"{item.RestaurantName},{item.NumberOfOrderedCustomer},{item.PriceInNis},{item.ProfitInUsd},{item.TheBestSellingMeal},{item.MostPurchasedCustomer}");
            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", $"items.csv");
        }

    }
}

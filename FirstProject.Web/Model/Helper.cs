using System.Linq;

namespace FirstProject.Web.Model
{
    public class Helper
    {
        private readonly restaurantdbContext _db;
        public  Helper(restaurantdbContext db)
        {
            _db = db;
        }
        public  bool isAvailable(int resturantMenuId)
        {
            var resturantObj = _db.RestaurantMenus.FirstOrDefault(x => x.Id == resturantMenuId);
            resturantObj.Id = resturantMenuId;
            if (resturantMenuId > 0) return true;
            return false;
        }
    }
}

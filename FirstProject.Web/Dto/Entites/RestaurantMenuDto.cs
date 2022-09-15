using System.Collections.Generic;

namespace FirstProject.Web.Dto.Entites
{
    public class RestaurantMenuDto :BaseEntityDto
    {
      
       
        public int Id { get; set; }
        public string MealName { get; set; }
        public double? PriceInNis { get; set; }
        public double? PriceInUsd {
        get { return PriceInNis  / 3.5; }
        set { PriceInUsd = value; }
         }
        public int? Quantity { get; set; }
        public int? RestaurantId { get; set; }

    }


}

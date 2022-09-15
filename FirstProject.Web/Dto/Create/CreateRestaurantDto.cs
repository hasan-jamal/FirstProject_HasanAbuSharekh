using FirstProject.Web.Dto.Entites;
using System.Collections.Generic;

namespace FirstProject.Web.Dto.Create
{
    public class CreateRestaurantDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
      
    }
}

using System.Collections.Generic;

namespace FirstProject.Web.Dto.Entites
{
    public class RestaurantDto : BaseEntityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<RestaurantMenuDto> RestaurantMenus { get; set; }
    }
}

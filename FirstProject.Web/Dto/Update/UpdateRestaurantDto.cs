using FirstProject.Web.Dto.Create;

namespace FirstProject.Web.Dto.Update
{
    public class UpdateRestaurantDto : CreateRestaurantDto 
    {
        public int Id { get; set; }
    }
}

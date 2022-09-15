namespace FirstProject.Web.Dto.Create
{
    public class CreateRestaurantMenuDto : BaseEntityDto
    {
        public string MealName { get; set; }
        public double? PriceInNis { get; set; }
        public int? Quantity { get; set; }
        public int? RestaurantId { get; set; }
    }
}

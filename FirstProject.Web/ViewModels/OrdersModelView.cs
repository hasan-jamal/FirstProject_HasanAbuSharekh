namespace FirstProject.Web.ViewModels
{
    public class OrdersModelView
        {
        public string RestaurantName { get; set; }
        public int? NumberOfOrderedCustomer { get; set; }
        public double? PriceInNis { get; set; }
        public double? ProfitInUsd { get; set; }
        public string TheBestSellingMeal { get; set; }
        public string MostPurchasedCustomer { get; set; }


    }
}

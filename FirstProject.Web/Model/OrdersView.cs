using System;
using System.Collections.Generic;

#nullable disable

namespace FirstProject.Web.Model
{
    public partial class OrdersView
    {
        public string RestaurantName { get; set; }
        public int? NumberOfOrderedCustomer { get; set; }
        public double? PriceInNis { get; set; }
        public double? ProfitInUsd { get; set; }
        public string TheBestSellingMeal { get; set; }
        public string MostPurchasedCustomer { get; set; }
    }
}

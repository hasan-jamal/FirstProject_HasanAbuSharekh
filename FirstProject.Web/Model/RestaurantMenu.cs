using System;
using System.Collections.Generic;

#nullable disable

namespace FirstProject.Web.Model
{
    public partial class RestaurantMenu :BaseEntity
    {
        public RestaurantMenu()
        {
            RestaurantMenuCustomers = new HashSet<RestaurantMenuCustomer>();
        }

        public int Id { get; set; }
        public string MealName { get; set; }
        public double? PriceInNis { get; set; }
        public double? PriceInUsd
        {
            get { return PriceInNis / 3.5; }
            set { PriceInUsd = value; }
        }
        public int? Quantity { get; set; }
        public int? RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<RestaurantMenuCustomer> RestaurantMenuCustomers { get; set; }
    }
}

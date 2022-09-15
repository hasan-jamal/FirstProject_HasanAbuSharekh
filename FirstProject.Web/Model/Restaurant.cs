using System;
using System.Collections.Generic;

#nullable disable

namespace FirstProject.Web.Model
{
    public partial class Restaurant :BaseEntity
    {
        public Restaurant()
        {
            RestaurantMenus = new HashSet<RestaurantMenu>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<RestaurantMenu> RestaurantMenus { get; set; }
    }
}

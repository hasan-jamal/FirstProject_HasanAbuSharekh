using System;
using System.Collections.Generic;

#nullable disable

namespace FirstProject.Web.Model
{
    public partial class Customer :BaseEntity
    {
        public Customer()
        {
            RestaurantMenuCustomers = new HashSet<RestaurantMenuCustomer>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public virtual ICollection<RestaurantMenuCustomer> RestaurantMenuCustomers { get; set; }
    }
}

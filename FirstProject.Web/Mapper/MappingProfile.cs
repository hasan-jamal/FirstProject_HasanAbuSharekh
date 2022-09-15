using AutoMapper;
using FirstProject.Web.Dto.Create;
using FirstProject.Web.Dto.Entites;
using FirstProject.Web.Dto.Update;
using FirstProject.Web.Model;

namespace FirstProject.Web.Mapper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>().ReverseMap();
            CreateMap<Restaurant, CreateRestaurantDto>().ReverseMap();
            CreateMap<Restaurant, UpdateRestaurantDto>().ReverseMap();

            CreateMap<Customer, CutomersDto>().ReverseMap();
            CreateMap<Customer, CreateCustomersDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomersDto>().ReverseMap();


            CreateMap<RestaurantMenu, RestaurantMenuDto>().ReverseMap();
            CreateMap<RestaurantMenu, CreateRestaurantMenuDto>().ReverseMap();
            CreateMap<RestaurantMenu, UpdateRestaurantMenuDto>().ReverseMap();


            CreateMap<RestaurantMenuCustomer, RestaurantMenuCustomerDto>().ReverseMap();
            CreateMap<RestaurantMenuCustomer, CreateRestaurantMenuCustomerDto>().ReverseMap();
            CreateMap<RestaurantMenuCustomer, UpdateRestaurantMenuCustomerDto>().ReverseMap();



        }
    }
}

using AutoMapper;

namespace Beca.KeyboardShop.Profiles
{
    public class OrderProfile: Profile
    {
        public OrderProfile() 
        {
            CreateMap<Entities.Order, Models.OrderDto>();
            CreateMap<Models.OrderForCreationDto, Entities.Order>();
            CreateMap<Entities.Order, Models.OrderForCreationDto>();
        }

    }
}

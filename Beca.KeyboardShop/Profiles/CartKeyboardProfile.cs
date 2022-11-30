using AutoMapper;

namespace Beca.KeyboardShop.Profiles
{
    public class CartKeyboardProfile: Profile
    {
        public CartKeyboardProfile() 
        {
            CreateMap<Entities.Cart_Keyboards, Models.CartKeyboardDto>();
            CreateMap<Entities.Cart_Keyboards, Models.CartKeyboardForCreationDto>();
            CreateMap<Models.CartKeyboardForCreationDto, Entities.Cart_Keyboards>();
        }
    }
}

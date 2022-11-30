using AutoMapper;

namespace Beca.KeyboardShop.Profiles
{
    public class KeyboardProfile: Profile
    {
        public KeyboardProfile() 
        {
            CreateMap<Entities.Keyboard, Models.KeyboardDto>();
            CreateMap<Entities.Keyboard, Models.KeyboardForCreationDto>();
            CreateMap<Models.KeyboardForCreationDto, Entities.Keyboard>();

        }
    }
}

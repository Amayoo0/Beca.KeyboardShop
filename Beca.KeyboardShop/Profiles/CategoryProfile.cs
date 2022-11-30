using AutoMapper;

namespace Beca.KeyboardShop.Profiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile() 
        {
            CreateMap<Entities.Category, Models.CategoryDto>();
            CreateMap<Entities.Category, Models.CategoryForCreationDto>();
            CreateMap<Models.CategoryForCreationDto, Entities.Category>();

            
        
        }
    }
}

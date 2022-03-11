using AutoMapper;
using static Skillsbox.Challenge.MovieBooking.API.Model.Category.Create;

namespace Skillsbox.Challenge.MovieBooking.API.Model.Category
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Get
            CreateMap<Core.Entities.Category, CategoryDto>().ReverseMap();

            // Create
            CreateMap<CreateCategoryCommand, Core.Entities.Category>();

            // Audit
        }
    }
}

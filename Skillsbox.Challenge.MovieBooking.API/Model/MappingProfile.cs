using AutoMapper;
using Skillsbox.Challenge.MovieBooking.API.Model.Category;
using Skillsbox.Challenge.MovieBooking.API.Model.Movie;
using static Skillsbox.Challenge.MovieBooking.API.Model.Category.Create;

namespace Skillsbox.Challenge.MovieBooking.API.Model
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Get
            CreateMap<Core.Entities.Category, CategoryDto>().ReverseMap();
            CreateMap<Core.Entities.Movie, MovieDto>().ReverseMap();
            CreateMap<Core.Entities.RunningTime, RunningTimeDto>().ReverseMap();
            CreateMap<Core.Entities.RunningDay, RunningDayDto>().ReverseMap();
            CreateMap<Core.Entities.RunningHourAndMinute, RunningHourAndMinuteDto>().ReverseMap();

            // Create
            CreateMap<CreateCategoryCommand, Core.Entities.Category>();

            // Audit
        }
    }
}

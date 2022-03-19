using Microsoft.EntityFrameworkCore;
using Skillsbox.Challenge.MovieBooking.Core.Entities;
using Skillsbox.Challenge.MovieBooking.Core.Enums;
using Skillsbox.Challenge.MovieBooking.Core.Interface.Cache;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;

namespace Skillsbox.Challenge.MovieBooking.Infrastructure.Repository
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly DbSet<Movie> _movies;
        public MovieRepository(ApplicationDbContext dbContext, Func<CacheTech, ICacheService> cacheService) : base(dbContext, cacheService)
        {
            _movies = dbContext.Set<Movie>();
        }

        public Task BulkInsert()
        {
            throw new NotImplementedException();
        }
    }
}

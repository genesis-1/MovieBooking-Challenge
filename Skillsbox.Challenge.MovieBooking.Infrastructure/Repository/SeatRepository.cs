using Microsoft.EntityFrameworkCore;
using Skillsbox.Challenge.MovieBooking.Core.Entities;
using Skillsbox.Challenge.MovieBooking.Core.Enums;
using Skillsbox.Challenge.MovieBooking.Core.Interface.Cache;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;

namespace Skillsbox.Challenge.MovieBooking.Infrastructure.Repository
{
     public class SeatRepository : GenericRepository<Seat>, ISeatRepository
    {
        private readonly DbSet<Seat> _seat;
        public SeatRepository(ApplicationDbContext dbContext, Func<CacheTech, ICacheService> cacheService) : base(dbContext, cacheService)
        {
            _seat = dbContext.Set<Seat>();
        }

    }
}

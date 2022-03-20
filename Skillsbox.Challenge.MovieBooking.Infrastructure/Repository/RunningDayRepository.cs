using Microsoft.EntityFrameworkCore;
using Skillsbox.Challenge.MovieBooking.Core.Entities;
using Skillsbox.Challenge.MovieBooking.Core.Enums;
using Skillsbox.Challenge.MovieBooking.Core.Interface.Cache;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;

namespace Skillsbox.Challenge.MovieBooking.Infrastructure.Repository
{
    public class RunningDayRepository : GenericRepository<RunningDay>, IRunningDayRepository

    {
        private readonly DbSet<RunningDay> _runningDays;
        public RunningDayRepository(ApplicationDbContext dbContext, Func<CacheTech, ICacheService> cacheService) : base(dbContext, cacheService)
        {
            _runningDays = dbContext.Set<RunningDay>();
        }
    }
}

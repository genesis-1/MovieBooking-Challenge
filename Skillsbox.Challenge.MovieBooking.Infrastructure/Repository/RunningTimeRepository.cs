using Microsoft.EntityFrameworkCore;
using Skillsbox.Challenge.MovieBooking.Core.Entities;
using Skillsbox.Challenge.MovieBooking.Core.Enums;
using Skillsbox.Challenge.MovieBooking.Core.Interface.Cache;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;

namespace Skillsbox.Challenge.MovieBooking.Infrastructure.Repository
{
    public class RunningTimeRepository : GenericRepository<RunningTime>, IRunningTimeRepository
    {
        private readonly DbSet<RunningTime> _runningTimes;
        public RunningTimeRepository(ApplicationDbContext dbContext, Func<CacheTech, ICacheService> cacheService) : base(dbContext, cacheService)
        {
            _runningTimes = dbContext.Set<RunningTime>();
        }
    }
}

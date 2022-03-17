using Microsoft.EntityFrameworkCore;
using Skillsbox.Challenge.MovieBooking.Core.Entities;
using Skillsbox.Challenge.MovieBooking.Core.Enums;
using Skillsbox.Challenge.MovieBooking.Core.Interface.Cache;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;


namespace Skillsbox.Challenge.MovieBooking.Infrastructure.Repository
{
    internal class RunningHourAndMinuteRepository : GenericRepository<RunningHourAndMinute>, IRunningHourAndMinuteRepository
    {
        private readonly DbSet<RunningHourAndMinute> _runningHourAndMinutes;
        public RunningHourAndMinuteRepository(ApplicationDbContext dbContext, Func<CacheTech, ICacheService> cacheService) : base(dbContext, cacheService)
        {
            _runningHourAndMinutes = dbContext.Set<RunningHourAndMinute>();
        }
    }
}

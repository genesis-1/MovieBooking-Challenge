using Skillsbox.Challenge.MovieBooking.Core.Enums;
using Skillsbox.Challenge.MovieBooking.Core.Interface.Cache;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillsbox.Challenge.MovieBooking.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _db;
        private readonly Func<CacheTech, ICacheService> _cacheService;

        public UnitOfWork(ApplicationDbContext db, Func<CacheTech, ICacheService> cacheService)
        {
            _db = db;
            _cacheService = cacheService;
            RunningHourAndMinuteRepository = new RunningHourAndMinuteRepository(_db,_cacheService);
            RunningTimeRepository = new RunningTimeRepository(_db,_cacheService);
            MovieRepository = new MovieRepository(_db,_cacheService);
            CategoryRepository = new CategoryRepository(_db,_cacheService);
            RunningDayRepository = new RunningDayRepository(_db,_cacheService);
            BookingRepository = new BookingRepository(_db,_cacheService);
            TicketRepository = new TicketRepository(_db,_cacheService);
            SeatsRepository = new SeatRepository(_db,_cacheService);
            AgeCategoryDetailRepository = new AgeCategoryDetailRepository(_db,_cacheService);
        }

        public IRunningDayRepository RunningDayRepository { get; private set; }

        public IRunningHourAndMinuteRepository RunningHourAndMinuteRepository { get; private set; }

        public IRunningTimeRepository RunningTimeRepository { get; private set; }

        public IMovieRepository MovieRepository { get; private set; }

        public ICategoryRepository CategoryRepository { get; private set; }

        public IBookingRepository BookingRepository { get; private set; }

        public ISeatRepository SeatsRepository { get; private set; }

        public ITicketRepository TicketRepository { get; private set; }

        public IAgeCategoryDetailRepository AgeCategoryDetailRepository { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

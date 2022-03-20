using Microsoft.EntityFrameworkCore;
using Skillsbox.Challenge.MovieBooking.Core.Entities;
using Skillsbox.Challenge.MovieBooking.Core.Enums;
using Skillsbox.Challenge.MovieBooking.Core.Interface.Cache;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;

namespace Skillsbox.Challenge.MovieBooking.Infrastructure.Repository
{
    public class TicketRepository : GenericRepository<Core.Entities.Ticket>, ITicketRepository
    {
        private readonly DbSet<Ticket> _ticket;
        public TicketRepository(ApplicationDbContext dbContext, Func<CacheTech, ICacheService> cacheService) : base(dbContext, cacheService)
        {
            _ticket = dbContext.Set<Ticket>();
        }
    }
}

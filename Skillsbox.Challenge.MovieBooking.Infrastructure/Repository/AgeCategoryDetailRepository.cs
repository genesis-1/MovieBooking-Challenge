using Microsoft.EntityFrameworkCore;
using Skillsbox.Challenge.MovieBooking.Core.Entities;
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
    public class AgeCategoryDetailRepository : GenericRepository<AgeCategoryDetail>, IAgeCategoryDetailRepository
    {
        private readonly DbSet<AgeCategoryDetail> _movies;
        public AgeCategoryDetailRepository(ApplicationDbContext dbContext, Func<CacheTech, ICacheService> cacheService) : base(dbContext, cacheService)
        {
            _movies = dbContext.Set<AgeCategoryDetail>();
        }
    }
}

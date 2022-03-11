using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Skillsbox.Challenge.MovieBooking.Core.Entities;
using Skillsbox.Challenge.MovieBooking.Core.Enums;
using Skillsbox.Challenge.MovieBooking.Core.Interface.Cache;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;
using Skillsbox.Challenge.MovieBooking.Infrastructure;
using Skillsbox.Challenge.MovieBooking.Infrastructure.Repository;

namespace Skillsbox.Challenge.MovieBooking.Infrastructure
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly DbSet<Category> _categories;
        public CategoryRepository(ApplicationDbContext dbContext, Func<CacheTech, ICacheService> cacheService) : base(dbContext, cacheService)
        {
            _categories = dbContext.Set<Category>();
        }
    }
}

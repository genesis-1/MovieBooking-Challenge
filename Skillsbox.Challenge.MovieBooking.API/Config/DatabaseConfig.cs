using Hangfire;
using Hangfire.SQLite;
using Microsoft.EntityFrameworkCore;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;
using Skillsbox.Challenge.MovieBooking.Infrastructure;

namespace Skillsbox.Challenge.MovieBooking.API.Config
{
    public static class DatabaseConfig
    {
        public static void SetupSqliteDb(this IServiceCollection services, IConfiguration configuration)
        {



            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseSqlite(connectionString));

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddHangfire(x => x.UseSQLiteStorage(connectionString));
            services.AddHangfireServer();
        }
    }
}

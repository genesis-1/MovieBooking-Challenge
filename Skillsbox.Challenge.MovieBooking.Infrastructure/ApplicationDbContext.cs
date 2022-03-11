using Microsoft.EntityFrameworkCore;
using Skillsbox.Challenge.MovieBooking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillsbox.Challenge.MovieBooking.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<RunningTime> RunningTimes { get; set; }
        public virtual DbSet<RunningDay> RunningDays { get; set; }
        public virtual DbSet<RunningHourAndMinute> RunningHourAndMinutes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}

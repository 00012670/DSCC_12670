using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DAL
{
    public class HabitTrackerContext : DbContext
    {
        public HabitTrackerContext(DbContextOptions<HabitTrackerContext> o) : base(o)
        {
            Database.EnsureCreated();
        }

        public DbSet<Habit> Habits { get; set; }
        public DbSet<Progress> Progresses { get; set; }
    }
}

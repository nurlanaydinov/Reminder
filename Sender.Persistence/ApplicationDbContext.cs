using Microsoft.EntityFrameworkCore;
using Sender.Domain.Entities;

namespace Sender.Persistence
{
    public class ApplicationDbContext : DbContext
    {     

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Reminder> Reminder { get; set; }
    }
}

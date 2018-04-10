using Microsoft.EntityFrameworkCore;
using eplanning.api.Models;

namespace eplanning.api.Data
{
    public class EplanningContext : DbContext
    {
        public EplanningContext(DbContextOptions<EplanningContext> options)
            : base(options)
        {
            // delete constructor code that seeded our data
        }

        protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);
        
        
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }



    }
}
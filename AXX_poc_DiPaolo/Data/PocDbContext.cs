using AXX_poc_DiPaolo.Models;
using Microsoft.EntityFrameworkCore;

namespace AXX_poc_DiPaolo.Data
{
    public class PocDbContext(DbContextOptions<PocDbContext> options)
        : DbContext(options)
    {
        public DbSet<Request> RequestsList { get; set; }
        public DbSet<TyreDealer> TyreDealerList { get; set; }
        public DbSet<Transporter> TransportersList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transporter>().HasKey(t => t.Username);
            modelBuilder.Entity<TyreDealer>().HasKey(t => t.Username);
            modelBuilder.Entity<Request>().HasKey(r => r.Id);
        }
    }
}

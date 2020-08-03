using Microsoft.EntityFrameworkCore;

namespace Swagger.Models
{
    public class MainContext : DbContext
    {
        public DbSet<LISTS_38_CATALOG> Lists_38_Catalogs { get; set; }
        public DbSet<LISTS_38_ITEM> Lists_38_Items { get; set; }

        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LISTS_38_ITEM>()
            .HasOne(o => o.LISTS_38_CATALOG)
            .WithMany(c => c.LISTS_38_ITEMS)
            .HasForeignKey(o => o.LIST_ID);
        }
    }
}

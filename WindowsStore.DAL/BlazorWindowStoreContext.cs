using Microsoft.EntityFrameworkCore;

namespace WindowsStore.DAL
{
    public class BlazorWindowStoreContext : DbContext
    {
        public BlazorWindowStoreContext(DbContextOptions<BlazorWindowStoreContext> options)
                : base(options)
        { }
        public DbSet<Order.Order> Orders { get; set; }
        public DbSet<Window.Window> Windows { get; set; }
        public DbSet<SubElement.SubElement> SubElements { get; set; }
        public DbSet<OrderedWindow.OrderedWindow> OrderedWindows { get; set; }
        public DbSet<OrderedWindowSubElement.OrderedWindowSubElement> OrderedWindowSubElements { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order.Order>()
                .HasIndex(p => p.OrderName)
                .IsUnique(true);

            modelBuilder.Entity<Window.Window>()
                .HasIndex(p => p.WindowName)
                .IsUnique(true);
        }
    }
}

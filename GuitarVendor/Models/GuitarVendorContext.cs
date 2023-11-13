using Microsoft.EntityFrameworkCore;

namespace GuitarVendor.Models
{
  public class GuitarVendorContext : DbContext
  {
    public DbSet<Store> Stores { get; set; }
    public DbSet<Guitar> Guitars { get; set; }
    public DbSet<StoreGuitar> StoreGuitars { get; set; }
    public GuitarVendorContext(DbContextOptions options) : base (options) { }
  }
}
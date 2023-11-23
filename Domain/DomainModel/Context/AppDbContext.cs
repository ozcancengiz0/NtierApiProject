using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DomainModel.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { base.OnConfiguring(optionsBuilder); optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NLayerProjectExample;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"); }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HotelOrder>()
                .HasOne(ho => ho.Room)
                .WithMany()
                .HasForeignKey(ho => ho.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HotelOrder>()
                .HasOne(ho => ho.Hotel)
                .WithMany()
                .HasForeignKey(ho => ho.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HotelOrder>()
                .HasOne(ho => ho.Agent)
                .WithMany()
                .HasForeignKey(ho => ho.AgentId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<TransferOrder> transferOrders { get; set; }
        public DbSet<Agent> agents { get; set; }
        public DbSet<Manager> managers { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<Hotel> hotels { get; set; }
        public DbSet<HotelOrder> hotelOrders { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Rotation> rotations { get; set; }
        public DbSet<Tour> tours { get; set; }
        public DbSet<TourOrder> tourOrders { get; set; }
    }
}

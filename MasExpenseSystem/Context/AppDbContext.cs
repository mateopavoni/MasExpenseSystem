using MasExpenseSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasExpenseSystem.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entidad =>
            {
                entidad.HasKey("UserId");
                entidad.Property("UserId").ValueGeneratedOnAdd();

                entidad.HasData(
                    new User()
                    {
                        UserId = 1,
                        FullName = "Mateo Francisco Pavoni",
                        Email = "mateopavoni@gmailcom",
                        Password = "12345"
                    });
            });

            modelBuilder.Entity<Service>(entidad =>
            {
                entidad.HasKey("ServiceId");
                entidad.Property("ServiceId").ValueGeneratedOnAdd();

                entidad.HasOne(entidad => entidad.User).WithMany(usuario => usuario.Services).HasForeignKey(entidad => entidad.UserId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Transaction>(entidad =>
            {
                entidad.HasKey("TransactionId");
                entidad.Property("TransactionId").ValueGeneratedOnAdd();

                entidad.HasOne(entidad => entidad.User).WithMany(usuario => usuario.Transactions).HasForeignKey(entidad => entidad.UserId).OnDelete(DeleteBehavior.Restrict);

                entidad.HasOne(entidad => entidad.Service).WithMany().HasForeignKey(entidad => entidad.ServiceId);

            });


        }
    }
}

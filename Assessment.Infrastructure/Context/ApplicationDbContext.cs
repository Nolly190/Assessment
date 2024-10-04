using Assessment.Domain.Entities;
using Assessment.Infrastructure.Repositories.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookReservation> BookReservations { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BookReservationNotification> BookReservationNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<User>(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration<RolePermission>(new RolePermissionEntityConfiguration());
            modelBuilder.ApplyConfiguration<Role>(new RoleEntityConfiguration());
            modelBuilder.ApplyConfiguration<Permission>(new PermissionEntityConfiguration());
            modelBuilder.ApplyConfiguration<UserInRole>(new UserInRoleEntityConfiguration());
            modelBuilder.ApplyConfiguration<Book>(new BookEntityConfiguration());
            modelBuilder.ApplyConfiguration<BookReservation>(new BookReservationEntityConfiguration());
            modelBuilder.ApplyConfiguration<BookReservationNotification>(new BookReservationNotificationEntityConfiguration());
        }
    }
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=AssesmentDb;Persist Security Info=False;MultipleActiveResultSets=True; Trusted_Connection=True;Encrypt=True;TrustServerCertificate=true;Connection Timeout=30;");
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Assessment.Domain.Entities;

namespace Assessment.Infrastructure.Repositories.EntityConfiguration
{
    internal class PermissionEntityConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(x => x.Name);
            builder.HasData(new List<Permission>
            {
                new Permission { Name = "AddBook", Id = 1, IsDeleted = false },
                new Permission { Name = "GetBook", Id = 2, IsDeleted = false },
                new Permission { Name = "SearchBook", Id = 3, IsDeleted = false },
                new Permission { Name = "BookReturn", Id = 4, IsDeleted = false },
                new Permission { Name = "ReservationNotification", Id = 5, IsDeleted = false },
                new Permission { Name = "BookCollection", Id = 6, IsDeleted = false },
                new Permission { Name = "ReserveBook", Id = 7, IsDeleted = false },
                new Permission { Name = "GetReservation", Id = 8, IsDeleted = false },
                new Permission { Name = "GetAllReservations", Id = 9, IsDeleted = false },
                new Permission { Name = "GetAllReservationNotifications", Id = 10, IsDeleted = false },
                new Permission { Name = "GetAllUsers", Id = 11, IsDeleted = false },
                new Permission { Name = "GetSingleUser", Id = 12, IsDeleted = false },
                new Permission { Name = "BlockUser", Id = 13, IsDeleted = false },
                new Permission { Name = "CreateRole", Id = 14, IsDeleted = false },
                new Permission { Name = "UsersInRole", Id = 15, IsDeleted = false },
                new Permission { Name = "AddUserToRole", Id = 16, IsDeleted = false },
                new Permission { Name = "RemoveUserFromRole", Id = 18, IsDeleted = false },
                new Permission { Name = "ViewAllPermission", Id = 17, IsDeleted = false },
                new Permission { Name = "ViewAllRoles", Id = 19, IsDeleted = false },
                new Permission { Name = "RemoveRole", Id = 20, IsDeleted = false }
            });
        }
    }
}



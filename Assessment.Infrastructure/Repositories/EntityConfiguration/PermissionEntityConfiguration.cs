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
                new Permission { Name = "ReserveBook", Id = 7, IsDeleted = false }
            });
        }
    }
}



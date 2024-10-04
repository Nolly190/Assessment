using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Assessment.Domain.Entities;

namespace Assessment.Infrastructure.Repositories.EntityConfiguration
{
    internal class RolePermissionEntityConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.PermissionId).IsRequired();
            builder.Property(x => x.RoleId).IsRequired();
            builder.HasData(new List<RolePermission>()
            {
                //Admin Permission Mapping
                 new RolePermission{ Id =1,RoleId =1, PermissionId = 1,DateCreated = DateTime.UtcNow, LastModified =DateTime.UtcNow},
                 new RolePermission{Id =2,RoleId =1, PermissionId = 2,DateCreated = DateTime.UtcNow, LastModified =DateTime.UtcNow},
                 new RolePermission{Id = 3, RoleId =1, PermissionId = 3,DateCreated = DateTime.UtcNow, LastModified =DateTime.UtcNow},
                 new RolePermission{Id =4,RoleId =1, PermissionId = 4,DateCreated = DateTime.UtcNow, LastModified =DateTime.UtcNow},
                 new RolePermission{Id = 5, RoleId =1, PermissionId = 5,DateCreated = DateTime.UtcNow, LastModified =DateTime.UtcNow},
                 new RolePermission{Id = 10, RoleId =1, PermissionId = 6,DateCreated = DateTime.UtcNow, LastModified =DateTime.UtcNow},

                 //User Permission Mapping
                 new RolePermission{Id =6,RoleId =2, PermissionId = 2,DateCreated = DateTime.UtcNow, LastModified =DateTime.UtcNow},
                 new RolePermission{Id = 7, RoleId =2, PermissionId = 3,DateCreated = DateTime.UtcNow, LastModified =DateTime.UtcNow},
                 new RolePermission{Id =8,RoleId =2, PermissionId = 7,DateCreated = DateTime.UtcNow, LastModified =DateTime.UtcNow},
                 new RolePermission{Id = 9, RoleId =2, PermissionId = 5,DateCreated = DateTime.UtcNow, LastModified =DateTime.UtcNow},

            });
        }
    }
}

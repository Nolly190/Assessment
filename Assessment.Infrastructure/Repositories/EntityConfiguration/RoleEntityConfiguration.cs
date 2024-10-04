using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Assessment.Domain.Entities;

namespace Assessment.Infrastructure.Repositories.EntityConfiguration
{
    internal class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.HasData(new List<Role>
            {
                new Role{Id=1, Name="Admin", DateCreated=DateTime.UtcNow,LastModified=DateTime.UtcNow, IsDeleted=false},
                new Role{Id=2, Name="User", DateCreated=DateTime.UtcNow,LastModified=DateTime.UtcNow, IsDeleted=false},
            });
        }
    }
}

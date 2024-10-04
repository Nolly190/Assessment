using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Assessment.Domain.Entities;

namespace Assessment.Infrastructure.Repositories.EntityConfiguration
{
    internal class UserInRoleEntityConfiguration : IEntityTypeConfiguration<UserInRole>
    {
        public void Configure(EntityTypeBuilder<UserInRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.RoleId).IsRequired();
            builder.HasData(new List<UserInRole> {
                new UserInRole{ Id=1, UserId=2, RoleId=1, DateCreated=DateTime.UtcNow, IsDeleted=false, LastModified=DateTime.UtcNow} });
        }
    }
}

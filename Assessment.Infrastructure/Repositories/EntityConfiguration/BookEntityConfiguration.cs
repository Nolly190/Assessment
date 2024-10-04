using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Assessment.Domain.Entities;

namespace Assessment.Infrastructure.Repositories.EntityConfiguration
{
    internal class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.Author);
            builder.Property(x=>x.Author).IsRequired().HasMaxLength(100);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Assessment.Domain.Entities;

namespace Assessment.Infrastructure.Repositories.EntityConfiguration
{
    internal class BookReservationEntityConfiguration : IEntityTypeConfiguration<BookReservation>
    {
        public void Configure(EntityTypeBuilder<BookReservation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.CustomerId).IsRequired();
            builder.HasIndex(x => x.CustomerId);
            builder.HasIndex(x => x.BookId);
            builder.Property(x=>x.BookId).IsRequired();
        }
    }
}

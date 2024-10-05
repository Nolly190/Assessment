using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Assessment.Domain.Entities;

namespace Assessment.Infrastructure.Repositories.EntityConfiguration
{
    internal class BookReservationNotificationEntityConfiguration : IEntityTypeConfiguration<BookReservationNotification>
    {
        public void Configure(EntityTypeBuilder<BookReservationNotification> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.BookId).IsRequired();
            builder.HasOne(x => x.Book).WithMany().HasForeignKey(x => x.BookId); ;
            builder.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId);
        }
    }
}

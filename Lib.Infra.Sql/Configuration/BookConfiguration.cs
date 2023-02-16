using Lib.Domain.Entites;
using Lib.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lib.Infra.Sql.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).IsRequired();

            builder.HasOne(a => a.Author).WithMany(a => a.Books).HasForeignKey(a => a.AuthorId);

            builder.HasOne(a => a.Publisher).WithMany(a => a.Books).HasForeignKey(a => a.PublisherId);

            builder.OwnsOne(a => a.Publication).Property(p => p.Year).IsRequired().HasColumnName(nameof(Publication.Year));

            builder.OwnsOne(a => a.Publication).Property(p => p.Edition).IsRequired().HasColumnName(nameof(Publication.Edition));
        }
    }
}

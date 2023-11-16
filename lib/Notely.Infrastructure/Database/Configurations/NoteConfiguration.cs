using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notely.Application.Notes;

namespace Notely.Infrastructure.Database.Configurations;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Content).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.Colour).HasMaxLength(20).IsRequired();

        builder.HasKey(x => x.Id);
    }
}

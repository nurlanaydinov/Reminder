using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sender.Domain.Entities;

namespace Sender.Persistence.EntityConfigurations
{
    public class ReminderConfigurations: IEntityTypeConfiguration<Reminder>
    {
        public void Configure(EntityTypeBuilder<Reminder> builder)
        {
            builder.ToTable("Reminder");
            builder.HasIndex(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.To)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Content)
               .IsRequired()
               .HasMaxLength(500);

            builder.Property(p => p.Method)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(p => p.SendAt)
              .IsRequired();

            builder.Property(p => p.CreatedDate)
                .HasDefaultValue(DateTime.UtcNow);

            builder.Property(p => p.Version)
                .HasDefaultValue(0);

        }
    }
}

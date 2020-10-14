using MenagerTasker.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenagerTasker.Core.Data.Configs
{
    internal sealed class ManagerConfig : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(m => m.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasMany(m => m.Tasks)
                .WithOne()
                .HasForeignKey(t => t.ManagerId);

            builder.HasData(new Manager(1, "Artem", "Komlev"));

        }
    }
}

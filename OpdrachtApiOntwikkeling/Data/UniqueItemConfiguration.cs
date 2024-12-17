using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpdrachtApiOntwikkeling.Models;
using System.ComponentModel.DataAnnotations;

namespace OpdrachtApiOntwikkeling.Data
{
    public class UniqueItemConfiguration : IEntityTypeConfiguration<UniqueItem>
    {
        public void Configure(EntityTypeBuilder<UniqueItem> builder)
        {
            builder.ToTable("UniqueItems");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).HasColumnName("unique_item_id");

            builder.Property(l => l.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(l => l.Price)
                .HasColumnName("price")
                .IsRequired(false)
                .HasDefaultValue(1);

            builder.Property(l => l.HighAlch)
                .HasColumnName("high_alch")
                .IsRequired(false)
                .HasDefaultValue(1);

            builder.Property(l => l.Image)
                .HasColumnName("image")
                .IsRequired(false)
                .HasDefaultValue("https://i.imgur.com/Ac1Eonb.jpeg");
        }
    }
}

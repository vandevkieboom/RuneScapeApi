using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpdrachtApiOntwikkeling.Models;
using System.ComponentModel.DataAnnotations;

namespace OpdrachtApiOntwikkeling.Data
{
    public class UniqueItemConfiguration : IEntityTypeConfiguration<UniqueItem>
    {
        //ik weet dat het instellen van primaire sleutel en kolomnamen niet nodig is, maar ik doe het toch voor de duidelijkheid
        public void Configure(EntityTypeBuilder<UniqueItem> builder)
        {
            builder.ToTable("UniqueItems");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).HasColumnName("id");

            builder.Property(l => l.Name)
                .HasColumnName("name");

            builder.Property(l => l.Price)
                .HasColumnName("price");

            builder.Property(l => l.HighAlch)
                .HasColumnName("high_alch");

            builder.Property(l => l.Image)
                .HasColumnName("image");
        }
    }
}

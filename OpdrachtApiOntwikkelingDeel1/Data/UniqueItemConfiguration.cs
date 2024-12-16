using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpdrachtApiOntwikkeling.Models;

namespace OpdrachtApiOntwikkeling.Data
{
    public class UniqueItemConfiguration : IEntityTypeConfiguration<UniqueItem>
    {
        public void Configure(EntityTypeBuilder<UniqueItem> builder)
        {
            builder.ToTable("UniqueItems");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).HasColumnName("unique_item_id");
            builder.Property(l => l.Name).HasColumnName("name");
            builder.Property(l => l.Price).HasColumnName("price");
            builder.Property(l => l.HighAlch).HasColumnName("high_alch");
            builder.Property(l => l.Image).HasColumnName("image");
        }
    }
}

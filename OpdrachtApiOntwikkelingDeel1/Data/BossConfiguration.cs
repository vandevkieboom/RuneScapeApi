using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpdrachtApiOntwikkeling.Models;

namespace OpdrachtApiOntwikkeling.Data
{
    public class BossConfiguration : IEntityTypeConfiguration<Boss>
    {
        public void Configure(EntityTypeBuilder<Boss> builder)
        {
            builder.ToTable("Bosses");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("boss_id");
            builder.Property(c => c.Name).HasColumnName("name");
            builder.Property(c => c.Hitpoints).HasColumnName("hitpoints");
            builder.Property(c => c.CombatLevel).HasColumnName("combat_level");
            builder.Property(c => c.Image).HasColumnName("image");
            builder.Property(c => c.UniqueItemId).HasColumnName("unique_item_id");

            builder.HasOne(b => b.UniqueItem)
                .WithOne()
                .HasForeignKey<Boss>(b => b.UniqueItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

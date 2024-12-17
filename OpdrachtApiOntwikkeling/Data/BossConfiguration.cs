using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpdrachtApiOntwikkeling.Models;
using System.ComponentModel.DataAnnotations;

namespace OpdrachtApiOntwikkeling.Data
{
    public class BossConfiguration : IEntityTypeConfiguration<Boss>
    {
        public void Configure(EntityTypeBuilder<Boss> builder)
        {
            builder.ToTable("Bosses");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("boss_id");

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Hitpoints)
                .HasColumnName("hitpoints")
                .IsRequired(false)
                .HasDefaultValue(1);

            builder.Property(c => c.CombatLevel)
                .HasColumnName("combat_level")
                .IsRequired(false)
                .HasDefaultValue(1);

            builder.Property(c => c.Image)
                .HasColumnName("image")
                .IsRequired(false)
                .HasDefaultValue("https://i.imgur.com/drRS2Tf.jpeg");

            builder.Property(c => c.UniqueItemId)
                .HasColumnName("unique_item_id")
                .IsRequired(false);

            builder.HasOne(b => b.UniqueItem)
                .WithOne()
                .HasForeignKey<Boss>(b => b.UniqueItemId)
                .OnDelete(DeleteBehavior.SetNull); //zet unique_item_id op null als unique item verwijderd wordt
        }
    }
}
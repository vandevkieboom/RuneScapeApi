using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpdrachtApiOntwikkeling.Models;
using System.ComponentModel.DataAnnotations;

namespace OpdrachtApiOntwikkeling.Data
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).HasColumnName("location_id");

            builder.Property(l => l.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(l => l.Description)
                .HasColumnName("description")
                .IsRequired(false);

            builder.Property(l => l.Image)
                .HasColumnName("image")
                .IsRequired(false)
                .HasDefaultValue("https://i.imgur.com/U06pWSy.jpeg");

            builder.Property(l => l.BossId)
                .HasColumnName("boss_id")
                .IsRequired(false);

            builder.HasOne(l => l.Boss)
                .WithOne()
                .HasForeignKey<Location>(l => l.BossId)
                .OnDelete(DeleteBehavior.SetNull); //zet boss_id op null als boss verwijderd wordt
        }
    }
}

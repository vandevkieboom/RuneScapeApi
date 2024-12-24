using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpdrachtApiOntwikkeling.Models;
using System.ComponentModel.DataAnnotations;

namespace OpdrachtApiOntwikkeling.Data
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        //ik weet dat het instellen van primaire sleutel en kolomnamen niet nodig is, maar ik doe het toch voor de duidelijkheid
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).HasColumnName("id");

            builder.Property(l => l.Name)
                .HasColumnName("name");

            builder.Property(l => l.Description)
                .HasColumnName("description");

            builder.Property(l => l.Image)
                .HasColumnName("image");

            builder.Property(l => l.BossId)
                .HasColumnName("boss_id");

            builder.HasOne(l => l.Boss)
                .WithOne()
                .HasForeignKey<Location>(l => l.BossId)
                .OnDelete(DeleteBehavior.SetNull); //zet boss_id op null als boss verwijderd wordt
        }
    }
}

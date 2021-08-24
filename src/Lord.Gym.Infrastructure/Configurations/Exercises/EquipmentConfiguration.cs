using Lord.Gym.Domain.Entities.Exercise;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lord.Gym.Infrastructure.Configurations.Exercises
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(200);
        }
    }
}
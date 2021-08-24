using Lord.Gym.Domain.Entities.Exercise;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lord.Gym.Infrastructure.Configurations.Exercises
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(200);
        }
    }
}
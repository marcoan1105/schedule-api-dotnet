using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Domain.Entities;

namespace Schedule.Data.Mapping
{
    public class AnimalTypeMap : IEntityTypeConfiguration<AnimalType>
    {
        public void Configure(EntityTypeBuilder<AnimalType> builder)
        {
                builder.Property(e => e.Id).ValueGeneratedOnAdd();
                builder.Property(e => e.Description).IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Domain.Entities;

namespace Schedule.Data.Mapping
{
    public class PeopleMap : IEntityTypeConfiguration<People>
    {
        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Document).IsRequired();
            builder.Property(e => e.Email).IsRequired();
        }
    }
}
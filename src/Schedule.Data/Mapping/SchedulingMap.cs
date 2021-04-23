using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Domain.Entities;

namespace Schedule.Data.Mapping
{
    public class SchedulingMap : IEntityTypeConfiguration<Scheduling>
    {
        public void Configure(EntityTypeBuilder<Scheduling> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.AnimalId).IsRequired();
            builder.Property(e => e.InitialDate).IsRequired();
            builder.Property(e => e.FinalDate).IsRequired();
        }
    }
}
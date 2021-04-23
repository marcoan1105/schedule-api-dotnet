using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Schedule.Domain.Entities;
using Schedule.Data.Mapping;

namespace Schedule.Data.Context
{
    public class ScheduleContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<AnimalType> AnimalType { get; set; }
        public DbSet<Scheduling> Scheduling { get; set; }
        public ScheduleContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PeopleMap());
            modelBuilder.ApplyConfiguration(new AnimalMap());
            modelBuilder.ApplyConfiguration(new AnimalTypeMap());
            modelBuilder.ApplyConfiguration(new SchedulingMap());
        }
    }
}
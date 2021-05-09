using Schedule.Data.Abstractions;
using Schedule.Data.Context;
using Schedule.Domain.Entities;
using Schedule.Domain.Interfaces;

namespace Schedule.Data.Repositories
{
    public class AnimalTypeRepository : Repository<AnimalType, ScheduleContext>, IAnimalTypeRepository
    {
        public AnimalTypeRepository(ScheduleContext context) : base(context)
        {
        }
    }
}
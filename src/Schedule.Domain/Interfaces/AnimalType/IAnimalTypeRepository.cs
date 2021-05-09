using System.Threading.Tasks;
using Schedule.Domain.Entities;

namespace Schedule.Domain.Interfaces
{
    public interface IAnimalTypeRepository
    {
        Task<AnimalType> InsertAsync(AnimalType animal);
        Task<AnimalType> UpdateAsync(AnimalType animal);
    }
}
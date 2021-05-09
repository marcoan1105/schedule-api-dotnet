
using System.Collections.Generic;
using System.Threading.Tasks;
using Schedule.Domain.Entities;
using Schedule.Dto;
using Schedule.Dto.Abstractions;

namespace Schedule.Domain.Interfaces
{
    public interface IAnimalRepository
    {
        Task<Animal> InsertAsync(Animal animal);
        Task<Animal> UpdateAsync(Animal animal);
        Task<Animal> RemoveAsync(int id);
        Task<Animal> GetById(int id);
        Task<PagedDto<AnimalDto>> GetAllData(AnimalGetAllDto animalGetAllDto);
        Task<List<Animal>> GetByPeople(int peopleId);
    }
}
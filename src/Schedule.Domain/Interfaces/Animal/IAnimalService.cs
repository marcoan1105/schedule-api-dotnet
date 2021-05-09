using System.Collections.Generic;
using System.Threading.Tasks;
using Schedule.Domain.Entities;
using Schedule.Domain.Models;
using Schedule.Dto;
using Schedule.Dto.Abstractions;

namespace Schedule.Domain.Interfaces
{
    public interface IAnimalService
    {
        Task<AnimalDto> Add(RequestAnimalDto requestAnimalDto);
        Task<PagedDto<AnimalDto>> GetAll(AnimalGetAllDto animalGetAllDto);
        Task<AnimalDto> GetById(int id);
        Task<AnimalDto> Update(RequestAnimalDto requestAnimalDto, int id);        
        Task<AnimalDto> Delete(int id);
    }
}
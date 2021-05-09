
using Schedule.Domain.Interfaces;
using Schedule.Data.Abstractions;
using Schedule.Data.Context;
using Schedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Schedule.Dto;
using Schedule.Data.Implementations;
using Schedule.Dto.Abstractions;
using System;
using System.Linq;

namespace Schedule.Data.Repositories
{
    public class AnimalRepository : Repository<Animal, ScheduleContext>, IAnimalRepository
    {
        public AnimalRepository(ScheduleContext context) : base(context)
        {
        }

        public async Task<PagedDto<AnimalDto>> GetAllData(AnimalGetAllDto animalGetAllDto)
        {
            var query = GetAll();
            
            if(!String.IsNullOrEmpty(animalGetAllDto.Name)){
                query = query.Where(e => EF.Functions.Like(e.Name, $"%{animalGetAllDto.Name}"));
            }

            return await query.PaginatedListAsync<Animal, AnimalDto>(animalGetAllDto);
        }

        public async Task<Animal> GetById(int id)
        {
            return await GetAll(e => e.Id == id).FirstOrDefaultAsync();
            
        }

        public async Task<List<Animal>> GetByPeople(int peopleId)
        {
            return await GetAll(e => e.PropleId == peopleId).ToListAsync();
        }
    }
}
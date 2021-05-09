using AutoMapper;
using Schedule.Domain.Entities;
using Schedule.Domain.Models;
using Schedule.Dto;

namespace Schedule.Domain.AutoMap
{
    public class AnimalProfile : Profile
    {
        public AnimalProfile()
        {
            #region EntityToDto
            CreateMap<Animal, AnimalDto>();
            #endregion

            #region DtoToModel
            CreateMap<AnimalDto, AnimalModel>();
            CreateMap<RequestAnimalDto, AnimalModel>();
            #endregion

            #region ModelToEntity
            CreateMap<AnimalModel, Animal>();
            #endregion
        }
    }
}
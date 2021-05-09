using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Schedule.Domain.Abstractions;
using Schedule.Domain.AutoMap;
using Schedule.Domain.Entities;
using Schedule.Domain.Interfaces;
using Schedule.Domain.Models;
using Schedule.Domain.Notification;
using Schedule.Dto;
using Schedule.Dto.Abstractions;

namespace Schedule.Service.Services
{
    public class AnimalService : ServiceBase, IAnimalService
    {
        private IAnimalRepository _animalRepository;
        public AnimalService(IAnimalRepository animalRepository, INotificationHandler notificationHandler) : base(notificationHandler)
        {
            _animalRepository = animalRepository;
        }

        public async Task<AnimalDto> Add(RequestAnimalDto requestAnimalDto){
            
            AnimalModel animalModel = requestAnimalDto.Map<RequestAnimalDto, AnimalModel>();

            if(!animalModel.IsValid){
                _notificationHandler.AddErrorResponseValidationResult(animalModel.ValidationResult);
                return null;
            }

            var animal = animalModel.Map<AnimalModel, Animal>();

            animal = await _animalRepository.InsertAsync(animal);

            return animal.Map<Animal, AnimalDto>(); 

        }

        public async Task<AnimalDto> Update(RequestAnimalDto requestAnimalDto, int id){

            var animalModel = requestAnimalDto.Map<RequestAnimalDto, AnimalModel>();

            if(!animalModel.IsValid){
                _notificationHandler.AddErrorResponseValidationResult(animalModel.ValidationResult);
                return null;
            }

            animalModel.Id = id;

            var animal = await _animalRepository.GetById(id);

            if(animal == null){
                _notificationHandler.AddNotification("Not Found", "Animal not found");
                return null;
            }

            if(!animalModel.IsValid){
                _notificationHandler.AddErrorResponseValidationResult(animalModel.ValidationResult);
                return null;
            }

            animal = animalModel.Map<AnimalModel, Animal>();

            animal = await _animalRepository.UpdateAsync(animal);

            return animal.Map<Animal, AnimalDto>(); 

        }

        public async Task<PagedDto<AnimalDto>> GetAll(AnimalGetAllDto animalGetAllDto){
            
            return await _animalRepository.GetAllData(animalGetAllDto);
        }

        public async Task<AnimalDto> GetById(int id)
        {
            var animal = await _animalRepository.GetById(id);

            if(animal == null){
                _notificationHandler.AddNotification("Not Found", "Animal not found");
                return null;
            }

            return animal.Map<Animal, AnimalDto>(); 
        }

        public async Task<AnimalDto> Delete(int id)
        {
            var animal = await _animalRepository.RemoveAsync(id);

            if(animal == null){
                _notificationHandler.AddNotification("Not Found", "Animal not found");
                return null;
            }

            return animal.Map<Animal, AnimalDto>();
        }
    }
}
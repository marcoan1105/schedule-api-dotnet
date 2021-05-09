using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Schedule.Api.Application.Abstractions;
using Schedule.Domain.Configuration.Error;
using Schedule.Domain.Interfaces;
using Schedule.Domain.Models;
using Schedule.Domain.Notification;
using Schedule.Dto;
using Schedule.Dto.Abstractions;

namespace Schedule.Api.Application.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerAbstraction
    {

        IAnimalService _animalService;

        public AnimalController(IAnimalService animalService, IMapper mapper, INotificationHandler notificationHandler) : base(mapper, notificationHandler)
        {
            _animalService = animalService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AnimalDto), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(int id){
            var animals = await _animalService.GetById(id);

            return CreateResponseOk(animals);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedDto<AnimalDto>), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] AnimalGetAllDto animalGetAllDto){
            var animals = await _animalService.GetAll(animalGetAllDto);

            return CreateResponseOk(animals);
        }

        [HttpPut]
        [ProducesResponseType(typeof(AnimalDto), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([FromBody] RequestAnimalDto animal){

            var animalDto = await _animalService.Add(animal);
            return CreateResponseOk(animalDto);            
        }

        [HttpPost("{id}")]
        [ProducesResponseType(typeof(AnimalDto), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] RequestAnimalDto animal, int id){

            var animalDto = await _animalService.Update(animal, id);
            return CreateResponseOk(animalDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AnimalDto), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id){

            var animalDto = await _animalService.Delete(id);
            return CreateResponseOk(animalDto);
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using Schedule.Domain.Interfaces;
using Schedule.Data.Repositories;

namespace Schedule.Data
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// This method add repositories dependences
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddEfCore(this IServiceCollection service){
            
            service.AddTransient<IAnimalRepository, AnimalRepository>();
            service.AddTransient<IAnimalTypeRepository, AnimalTypeRepository>();
            return service;
        }
    }
}
using Schedule.Domain.Interfaces;
using Schedule.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Schedule.Service
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// This method add Services dependences
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection service){

            service.AddTransient<IAnimalService, AnimalService>();
            return service;
        }
    }
}
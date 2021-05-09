using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Schedule.Domain.AutoMap
{
    public static class ServiceCollectionExtension
    {
        public static IMapper Mapper { get; private set; }

        /// <summary>
        /// This method add mapper's configurations
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection service){

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AnimalProfile());
            });

            Mapper = config.CreateMapper();

            service.AddSingleton<IMapper>(Mapper);

            return service;
        }
    }
}
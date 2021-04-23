using Microsoft.Extensions.DependencyInjection;

namespace Schedule.Data
{
    public static class ServiceCollectionExtends
    {
        public static IServiceCollection AddEfCore(this IServiceCollection service){
            
            return service;
        }
    }
}
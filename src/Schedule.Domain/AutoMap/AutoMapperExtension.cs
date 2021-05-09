using System.Collections.Generic;

namespace Schedule.Domain.AutoMap
{
    public static class AutoMapperExtension
    {
        public static List<TDto> Map<TEntity, TDto>(this List<TEntity> list){
            return Schedule.Domain.AutoMap.ServiceCollectionExtension.Mapper.Map<List<TEntity>, List<TDto>>(list);
        }

        public static TDto Map<TEntity, TDto>(this TEntity item){
            return Schedule.Domain.AutoMap.ServiceCollectionExtension.Mapper.Map<TEntity, TDto>(item);
        }
    }
}
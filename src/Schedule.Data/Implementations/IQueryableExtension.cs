using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Schedule.Domain.Abstractions;
using Schedule.Domain.AutoMap;
using Schedule.Dto;
using Schedule.Dto.Abstractions;

namespace Schedule.Data.Implementations
{
    public static class IQueryableExtension
    {
        private static int MaxPageSize = 500;
        public async static Task<PagedDto<TDto>> PaginatedListAsync<TEntity, TDto>(this IQueryable<TEntity> query, GetAllDto getAllDto)
        where TEntity : Entity
        where TDto : BaseDto
        {

            // validations
            getAllDto.PageNumber = (getAllDto.PageNumber <= 0) ? 1 : getAllDto.PageNumber;
            getAllDto.PageSize = (getAllDto.PageSize > MaxPageSize) || (getAllDto.PageSize <= 0) ? MaxPageSize : getAllDto.PageSize;
            

            PagedDto<TDto> pagedDto = new PagedDto<TDto>();
            
            pagedDto.PageSize = getAllDto.PageSize;
            pagedDto.CurrentPage = getAllDto.PageNumber;

            var quantityItens = await query.CountAsync();

            var startRow = (getAllDto.PageNumber - 1) * getAllDto.PageSize;
            var results = await query
                       .Skip(startRow)
                       .Take(getAllDto.PageSize)
                       .ToListAsync();

            pagedDto.Items = results.Map<TEntity, TDto>();

            pagedDto.TotalItems = quantityItens;
            pagedDto.TotalPages = (int)Math.Ceiling(pagedDto.TotalItems / (double)getAllDto.PageSize);

            return pagedDto;
        }
    }
}
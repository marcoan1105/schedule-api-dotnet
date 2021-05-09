using System.Collections.Generic;

namespace Schedule.Dto.Abstractions
{
    public class PagedDto<TDto>
    {       
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public IList<TDto> Items { get; set; }

        public PagedDto()
        {
            Items = new List<TDto>();
        }
    }
}
namespace Schedule.Dto.Abstractions
{
    public class GetAllDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }        
        public string Filter { get; set; }
        
    }
}
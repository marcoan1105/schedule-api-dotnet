using Schedule.Dto.Abstractions;

namespace Schedule.Dto
{
    public class AnimalGetAllDto : GetAllDto
    {
        public int[] Id { get; set; }
        public int[] PropleId { get; set; }
        public int[] AnimalTypeId { get; set; }
        public string Name { get; set; }
        public string FavoriteToy { get; set; }
        public string Photo { get; set; }
        public string Note { get; set; }
    }
}
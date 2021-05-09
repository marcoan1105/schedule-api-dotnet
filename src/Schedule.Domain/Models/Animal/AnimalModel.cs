using Schedule.Domain.Validations;

namespace Schedule.Domain.Models
{
    public class AnimalModel : Model<AnimalModel>
    {
        public int PropleId { get; set; }
        public int AnimalTypeId { get; set; }
        public string Name { get; set; }
        public string FavoriteToy { get; set; }
        public string Photo { get; set; }
        public string Note { get; set; }

        public AnimalModel()
        {
            
        }
        
        public AnimalModel(int propleId, int animalTypeId, string name, string favoriteToy, string photo, string note)
        {
            PropleId = propleId;
            AnimalTypeId = animalTypeId;
            Name = name;
            FavoriteToy = favoriteToy;
            Photo = photo;
            Note = note;

            Include(new AnimalModelRequiredValidate());

            ValidateModel(this);
        }
    }
}
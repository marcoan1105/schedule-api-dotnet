using Schedule.Domain.Abstractions;
using System.Collections.Generic;
using System;

namespace Schedule.Domain.Entities
{
    public class Animal : Entity
    {
        public int PropleId { get; set; }
        public int AnimalTypeId { get; set; }
        public string Name { get; set; }
        public string FavoriteToy { get; set; }
        public string Photo { get; set; }
        public string Note { get; set; }

        public Animal(int propleId, int animalTypeId, string name, string favoriteToy, string photo, string note)
        {
            PropleId = propleId;
            AnimalTypeId = animalTypeId;
            Name = name;
            FavoriteToy = favoriteToy;
            Photo = photo;
            Note = note;
        }
    }
}
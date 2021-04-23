using Schedule.Domain.Abstractions;
using System.Collections.Generic;
using System;

namespace Schedule.Domain.Entities
{
    public class Animal : Entity
    {
        public int Id { get; set; }
        public int PropleId { get; set; }
        public int AnimalTypeId { get; set; }
        public string Name { get; set; }
        public string FavoriteToy { get; set; }
        public string Photo { get; set; }
        public string Note { get; set; }
    }
}
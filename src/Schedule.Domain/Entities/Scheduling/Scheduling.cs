using System;
using Schedule.Domain.Abstractions;

namespace Schedule.Domain.Entities
{
    public class Scheduling : Entity
    {
        public int AnimalId { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string Note { get; set; }
    }
}
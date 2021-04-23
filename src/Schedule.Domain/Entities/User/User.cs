using Schedule.Domain.Abstractions;

namespace Schedule.Domain.Entities
{
    public class User : Entity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
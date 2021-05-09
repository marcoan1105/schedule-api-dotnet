using Schedule.Domain.Abstractions;

namespace Schedule.Domain.Entities
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
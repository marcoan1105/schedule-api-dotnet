namespace Schedule.Domain.Entities
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public bool Customer { get; set; }
        public bool Employee { get; set; }
    }
}
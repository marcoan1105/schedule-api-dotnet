namespace Schedule.Domain.Configuration.Error
{
    public class ErrorMessage
    {
        public string Name { get; set; }
        public string Message { get; set; }

        public ErrorMessage(string name, string message)
        {
            Name = name;
            Message = message;
        }        
    }
}
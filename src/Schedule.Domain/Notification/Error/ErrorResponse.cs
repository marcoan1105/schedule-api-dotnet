using System.Collections.Generic;

namespace Schedule.Domain.Configuration.Error
{
    public class ErrorResponse
    {
        public List<ErrorMessage> ErrorMessage { get; set; } = new List<ErrorMessage>();
    }
}
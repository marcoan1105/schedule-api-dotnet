using System.Linq;
using FluentValidation.Results;
using Schedule.Domain.Configuration.Error;

namespace Schedule.Domain.Notification
{
    public class NotificationHandler : INotificationHandler
    {
        public ErrorResponse ErrorResponse { get; set; } = new ErrorResponse();

        public void AddErrorResponseValidationResult(ValidationResult validationResult){
            validationResult.Errors.ForEach(e => AddNotification(e.PropertyName, e.ErrorMessage));
        }

        public void AddNotification(string name, string message){
            ErrorResponse.ErrorMessage.Add(new ErrorMessage(name, message));
        }

        public ErrorResponse GetErrorResponse()
        {
            return ErrorResponse;
        }

        public bool HasError()
        {
            return ErrorResponse.ErrorMessage.Count() > 0;
        }
    }
}
using FluentValidation.Results;
using Schedule.Domain.Configuration.Error;

namespace Schedule.Domain.Notification
{
    public interface INotificationHandler
    {
         void AddErrorResponseValidationResult(ValidationResult validationResult);
         void AddNotification(string name, string message);
         ErrorResponse GetErrorResponse();         
         bool HasError();
    }
}
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace Schedule.Domain.Models
{
    public class Model<T> : AbstractValidator<T> where T : Model<T>
    {
        public int Id { get; set; }

        public bool IsValid { get {
            return ValidationResult.IsValid;
        } }

        public List<ValidationFailure> Errors { get {
            return ValidationResult.Errors;
        } }
        
        public ValidationResult ValidationResult { get; set; }

        public void ValidateModel(T obj){
            ValidationResult = Validate(obj);
        }
    }
}
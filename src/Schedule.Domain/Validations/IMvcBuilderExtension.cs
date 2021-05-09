using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Schedule.Domain.Validations
{
    public static class IMvcBuilderExtension
    {
        /// <summary>
        /// This method add Validators to Startup
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <returns></returns>
        public static IMvcBuilder AddValidations(this IMvcBuilder mvcBuilder){
            return mvcBuilder.AddFluentValidation(fv => {
                //fv.RegisterValidatorsFromAssemblyContaining<RequestAnimalDtoValidate>();

               
            });
        }
    }
}
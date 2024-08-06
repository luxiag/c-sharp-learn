using System.ComponentModel.DataAnnotations;
using web_api_v8.Dtos;

namespace web_api_v8.ValidationAttributes
{
    public class TouristRouteTitleMustBeDifferentFromDescriptionAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);
            var touristRouteDto = (TouristRouteForManipulationDto)validationContext.ObjectInstance;
            if (touristRouteDto.Title == touristRouteDto.Description)
            {
                return new ValidationResult("路线名称必须与路线描述不同", new[] { "TouristRouteForCreationDto" });


            }
            return ValidationResult.Success;
        }
    }
}

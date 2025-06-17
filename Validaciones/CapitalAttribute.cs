using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Validaciones
{
    public class CapitalAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null || string.IsNullOrWhiteSpace(value.ToString())) return ValidationResult.Success;
            var capital = value.ToString()![0].ToString();
            if(capital != capital.ToUpper()) return new ValidationResult("La primera letra debe ser mayuscula");
            return ValidationResult.Success;
        }
    }
}

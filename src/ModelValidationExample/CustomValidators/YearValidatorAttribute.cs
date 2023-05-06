using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.CustomValidators
{
  public class YearValidatorAttribute: ValidationAttribute
  {
    public int MinimumYear { get; set; } = 2000;
    public string DefaultErrorMessage { get; set; } = "Year should not be less that {0}";

    //constroctors
    public YearValidatorAttribute() 
    { 
    }

    public YearValidatorAttribute(int minimumYear)
    {
      MinimumYear = minimumYear;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
      if(value != null)
      {
        DateTime date = (DateTime)value;
        if(date.Year >= MinimumYear)
        {
          return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear));
        }
        else
        {
          return ValidationResult.Success;
        }
      }
      return null;
    }
  }
}

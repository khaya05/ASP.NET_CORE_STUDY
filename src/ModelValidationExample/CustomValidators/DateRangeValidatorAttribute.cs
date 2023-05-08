using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidationExample.CustomValidators
{
  public class DateRangeValidatorAttribute: ValidationAttribute
  {
    public string? OtherProp { get; set; }

    public DateRangeValidatorAttribute(string? otherProp)
    {
      OtherProp = otherProp;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
      if(value != null)
      {
        // get toDate
        DateTime toDate = (DateTime)value;

        //get fromDate
        PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherProp);

        if (otherProperty != null)
        {
          DateTime fromDate = (DateTime)otherProperty.GetValue(validationContext.ObjectInstance);

          if (fromDate > toDate)
          {
            return new ValidationResult(ErrorMessage, new string[] { OtherProp, validationContext.MemberName });
          }
          else
          {
            return ValidationResult.Success;
          }
        }
        return null;
      }
      return null;
    }
  }
}

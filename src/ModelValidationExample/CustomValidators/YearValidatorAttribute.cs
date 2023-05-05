﻿using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.CustomValidators
{
  public class YearValidatorAttribute: ValidationAttribute
  {
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
      if(value != null)
      {
        DateTime date = (DateTime)value;
        if(date.Year >= 200)
        {
          return new ValidationResult("Minimum year allowed is 2000");
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

﻿using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.Modals
{
  public class Person
  {
    [Required(ErrorMessage = "{0} cannot be empty or null.")]
    [Display(Name = "Person Name")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} be between {2} to {1} characters")]
    [RegularExpression("^[A-Za-z .]$", ErrorMessage = "{0} should contain only alphabets, space and dot(.)")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "{0} is requred!")]
    [EmailAddress(ErrorMessage ="{0} should be a valid email address.")]
    public string? Email { get; set; }

    [Phone(ErrorMessage ="{0} should be a valid phone number.")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "{0} is requred!")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "{0} is requred!")]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "{0} and {1} do not match.")]
    public string? ConfirmPassword { get; set;}

    [Range(0, 999, ErrorMessage = "{0} should be between ${0} and ${1}")]
    public double? Price { get; set;}

    public override string ToString()
    {
      return $"Person object - Person name:{Name}, Email:{Email}, Phone: {Phone}, Password: {Password}, Confirm Password: {ConfirmPassword}, Price: {Price}";
    }
  }
}

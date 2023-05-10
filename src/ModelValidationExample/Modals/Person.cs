using ModelValidationExample.CustomValidators;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidationExample.Modals
{
  public class Person: IValidatableObject
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

    [YearValidator(2005, ErrorMessage = "Date of Birth should be Jan 01, {0} or younger")]
    public DateTime? DateOfBirth { get; set; }

    public DateTime? FromDate { get; set; }

    [DateRangeValidator("FromDate", ErrorMessage = "'From Date' should be older than or equal to 'To date'")]
    public DateTime? ToDate { get; set; }

    public int? Age { get; set; }

    public override string ToString()
    {
      return $"Person object - Person name:{Name}, Email:{Email}, Phone: {Phone}, Password: {Password}, Confirm Password: {ConfirmPassword}, Price: {Price}";
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if(DateOfBirth.HasValue == false && Age.HasValue == false)
      {
        yield return new ValidationResult("Either Date of bitrh or Age must be empty|", new[] { nameof(Age) });
      }
    }
  }
}

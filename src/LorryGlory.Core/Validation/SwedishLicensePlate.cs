using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LorryGloryMockApi.Core.Validation;

/// <summary>
/// Validates that the input string is in the format of a swedish license plate - either "ABC123" or "ABC12D". Does not handle custom license plates.
/// </summary>
public class SwedishLicensePlateAttribute : ValidationAttribute
{
    private static readonly Regex LicensePlateRegex = new Regex("^[A-Z]{3}\\d{2}[A-Z\\d]{1}$", RegexOptions.IgnoreCase);

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string licensePlate && LicensePlateRegex.IsMatch(licensePlate))
        {
            return ValidationResult.Success;
        }
        return new ValidationResult("Invalid license plate format.");
    }
}

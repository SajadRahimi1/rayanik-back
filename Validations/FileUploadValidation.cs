using System.ComponentModel.DataAnnotations;

public class ValidatePdfAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {

        var file = value as IFormFile;
        if (file == null)
        {
            return new ValidationResult("file can't be null");
        }

        var extension = Path.GetExtension(file.FileName).ToLower();
        if (extension != "pdf")
        {
            return new ValidationResult("only pdf files are allowed");
        }

        return ValidationResult.Success;
    }
}

public class ValidateImageAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {

        var file = value as IFormFile;
        if (file == null)
        {
            return new ValidationResult("file can't be null");
        }

        var extension = Path.GetExtension(file.FileName).ToLower();
        if (extension != "jpg" || extension != "jpeg" || extension != "png")
        {
            return new ValidationResult("only pdf files are allowed");
        }

        return ValidationResult.Success;
    }
}

public class ValidateVideoAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {

        var file = value as IFormFile;
        if (file == null)
        {
            return new ValidationResult("file can't be null");
        }

        var extension = Path.GetExtension(file.FileName).ToLower();
        if (extension != "mp4")
        {
            return new ValidationResult("only pdf files are allowed");
        }

        return ValidationResult.Success;
    }
}
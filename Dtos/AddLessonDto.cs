using System.ComponentModel.DataAnnotations;

public class AddLessonDto
{

    [Required]
    public Guid courseId { get; set; }

    [Required]
    public string? title { get; set; }
    public string? description { get; set; }

    [Required]
    [ValidateVideo]
    public IFormFile? video { get; set; }

    [Required]
    [ValidateImage]
    public IFormFile? image { get; set; }

    public int weekNumber { get; set; } = 1;
}
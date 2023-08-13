using System.ComponentModel.DataAnnotations;

public class AddLessonDto
{

    [Required]
    public Guid courseId { get; set; }

    [Required]
    public string? title { get; set; }
    public string? description { get; set; }

    [Required]
    public IFormFile video { get; set; }
}
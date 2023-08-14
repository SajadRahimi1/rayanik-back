using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class CreateCoursDto
{

    [Required]
    public string? title { get; set; }

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public LearningCategory category { get; set; }

    public string? price { get; set; }

    public int weeksCount { get; set; } = 1;

    [Required]
    public IFormFile image { get; set; }

}
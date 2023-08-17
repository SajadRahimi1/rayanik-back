using System.ComponentModel.DataAnnotations;

public class AddBookDto
{

    [Required]
    public string? title { get; set; }

    [Required]
    public string? author { get; set; }

    [Required]
    public string? publisher { get; set; }

    [Required]
    [ValidatePdf]
    public IFormFile pdf { get; set; }
    public string? description { get; set; }

    [Required]
    [ValidateImage]
    public IFormFile image { get; set; }

    public string? downloadUrl { get; set; }
    public string? imageUrl { get; set; }
}
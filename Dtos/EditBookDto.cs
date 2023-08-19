using System.ComponentModel.DataAnnotations;

public class EditBookDto
{
    [Required]
    public Guid? Id { get; set; }

    [Required]
    public string? title { get; set; }

    [Required]
    public string? author { get; set; }

    [Required]
    public string? publisher { get; set; }

    [ValidatePdf]
    public IFormFile? pdf { get; set; }
    public string? description { get; set; }

    [ValidateImage]
    public IFormFile? image { get; set; }

    public string? downloadUrl { get; set; }
    public string? imageUrl { get; set; }
}
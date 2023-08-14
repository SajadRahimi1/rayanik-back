public class Lesson : BaseEntity
{
    public Guid courseId { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? imageUrl { get; set; }
    public string? videoUrl { get; set; }
    public int weekNumber { get; set; }=1;
}

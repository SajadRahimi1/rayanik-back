public class Course : BaseEntity
{
    public string? title { get; set; }
    public LearningCategory category { get; set; }
    public string? price { get; set; }
    public int weeksCount { get; set; }=1;

    public string? imageUrl { get; set; }
    public List<Lesson> lessons { get; set; } = new List<Lesson>();
}

public enum LearningCategory
{
    web,
    application,
    programming,
    design
}

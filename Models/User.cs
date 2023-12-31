public class User : BaseEntity
{
    public string? fullName { get; set; }
    public string? phoneNumber { get; set; }
    public string? email { get; set; }
    public string? code { get; set; }
    public List<Course> courses { get; set; } = new List<Course>();
}

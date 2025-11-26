namespace CourseManagmentAPI.Entities;

public class Course
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string DifficultyLevel { get; set; }
    public int Duration { get; set; }
    
    public ICollection<Student>? Students { get; set; }
    public ICollection<Module>? Modules { get; set; }
}
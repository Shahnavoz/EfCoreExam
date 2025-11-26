using System.ComponentModel.DataAnnotations;

namespace CourseManagmentAPI.Entities;

public class Student
{
    public long Id { get; set; }
    [MaxLength(60)]
    public string FullName { get; set; }
    [MaxLength(60)]
    public string Email { get; set; }
    public DateTime RegistrationDate { get; set; }=DateTime.Now;
    public long CourseId { get; set; }
    public Course? Course { get; set; }
}
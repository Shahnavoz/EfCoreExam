using CourseManagmentAPI.Entities;
using MiniLibraryAPI.Responses;

namespace CourseManagmentAPI.Services.Interfaces;

public interface IStudentCourse
{
    Task<List<Entities.StudentCourse>> GetStudentCoursesAsync();
    Task<Response<Entities.StudentCourse>> GetStudentCourseByIdAsync(int courseId);
    Task<Response<string>> CreateStudentCourse(StudentCourse studentCourse);
    Task<Response<string>> UpdateStudentCourse(StudentCourse studentCourse);
    Task<Response<string>> DeleteStudentCourse(int courseId);
}
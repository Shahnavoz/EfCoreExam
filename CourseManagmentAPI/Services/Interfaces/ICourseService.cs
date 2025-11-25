using CourseManagmentAPI.Entities;
using MiniLibraryAPI.Responses;

namespace CourseManagmentAPI.Services.Interfaces;

public interface ICourseService
{
    Task<List<Course>> GetCoursesAsync();
    Task<Response<Course>> GetCourseAsync(int id);
    Task<Response<string>> CreateCourse(Course course);
    Task<Response<string>> UpdateCourse(Course course);
    Task<Response<string>> DeleteCourse(int courseId);
}
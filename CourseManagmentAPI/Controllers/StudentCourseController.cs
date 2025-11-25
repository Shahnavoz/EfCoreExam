using CourseManagmentAPI.Entities;
using CourseManagmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MiniLibraryAPI.Responses;

namespace CourseManagmentAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class StudentCourseController(IStudentCourse studentCourseService):ControllerBase
{
    [HttpGet("GetStudentCourses")]
    public async Task<List<StudentCourse>> GetStudentCoursesAsync()
    {
        return await studentCourseService.GetStudentCoursesAsync();
    }

    [HttpGet]
    public async Task<Response<StudentCourse>> GetStudentCourseAsync(int id)
    {
        return await studentCourseService.GetStudentCourseByIdAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> CreateStudentCourseAsync(StudentCourse studentCourse)
    {
        return await studentCourseService.CreateStudentCourse(studentCourse);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateStudentCourseAsync(StudentCourse studentCourse)
    {
        return await studentCourseService.UpdateStudentCourse(studentCourse);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteStudentCourseAsync(int id)
    {
        return await studentCourseService.DeleteStudentCourse(id);
    }
    
}
using CourseManagmentAPI.Entities;
using CourseManagmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MiniLibraryAPI.Responses;

namespace CourseManagmentAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CourseController(ICourseService courseService):ControllerBase
{
    [HttpGet("GetAllCourses")]
    public async Task<List<Course>> GetAllCoursesAsync()
    {
        return await courseService.GetCoursesAsync();
    }

    [HttpGet]
    public async Task<Response<Course>> GetCourseById(int courseId)
    {
        return await courseService.GetCourseAsync(courseId);
    }

    [HttpPost]
    public async Task<Response<string>> CreateCourse(Course course)
    {
        return await courseService.CreateCourse(course);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateCourse(Course course)
    {
        return await courseService.UpdateCourse(course);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteCourse(int courseId)
    {
        return await courseService.DeleteCourse(courseId);
    }
    
}
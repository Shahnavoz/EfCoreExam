using CourseManagmentAPI.Entities;
using CourseManagmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MiniLibraryAPI.Responses;

namespace CourseManagmentAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudentController(IStudentService studentService):ControllerBase
{
    [HttpGet("GetStudents")]
    public async Task<List<Student>> GetStudents()
    {
        return await studentService.GetAllStudents();
    }

    [HttpGet]
    public async Task<Response<Student>> GetStudent(int id)
    {
        return await studentService.GetStudentById(id);
    }

    [HttpPost]
    public async Task<Response<string>> CreateStudent([FromBody] Student student)
    {
        return await studentService.CreateStudent(student);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateStudent([FromBody] Student student)
    {
        return await studentService.UpdateStudent(student);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteStudent(int id)
    {
        return await studentService.DeleteStudent(id);
    }

}
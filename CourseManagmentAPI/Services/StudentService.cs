using System.Net;
using CourseManagmentAPI.Data;
using CourseManagmentAPI.Entities;
using CourseManagmentAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MiniLibraryAPI.Responses;

namespace CourseManagmentAPI.Services;

public class StudentService(ApplicationDbContext  context):IStudentService
{
    public async Task<List<Student>> GetAllStudents()
    {
        return await context.Students.ToListAsync();
    }

    public async Task<Response<Student>> GetStudentById(int studentId)
    {
        var student = await context.Students.FindAsync(studentId);
        return student==null ? new Response<Student>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<Student>(HttpStatusCode.OK,"Found successfully!", student);
    }

    public async Task<Response<string>> CreateStudent(Student student)
    {
        var result = await context.Students.AddAsync(student);
        context.SaveChanges();
        return result==null ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<string>(HttpStatusCode.OK, "Created successfully!");
    }

    public async Task<Response<string>> UpdateStudent(Student student)
    {
        var result=context.Students.Update(student);
        context.SaveChanges();
        return result==null ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<string>(HttpStatusCode.OK, "Updated successfully!");
    }

    public async Task<Response<string>> DeleteStudent(int studentId)
    {
        var result =await context.Students.Where(s => s.Id == studentId).ExecuteDeleteAsync();
        return result==null ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<string>(HttpStatusCode.OK, "Deleted successfully!");
    }
}
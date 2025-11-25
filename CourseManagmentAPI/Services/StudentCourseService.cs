using System.Net;
using CourseManagmentAPI.Data;
using CourseManagmentAPI.Entities;
using CourseManagmentAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MiniLibraryAPI.Responses;

namespace CourseManagmentAPI.Services;

public class StudentCourseService(ApplicationDbContext context):IStudentCourse
{
    public async Task<List<StudentCourse>> GetStudentCoursesAsync()
    {
        return await context.StudentCourse.ToListAsync();
    }

    public async Task<Response<StudentCourse>> GetStudentCourseByIdAsync(int courseId)
    {
        var result = await context.StudentCourse.Where(m => m.Id == courseId).FirstOrDefaultAsync();
        return result==null ? new Response<StudentCourse>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<StudentCourse>(HttpStatusCode.OK,"Found Successfully!",result);
    }

    public async Task<Response<string>> CreateStudentCourse(StudentCourse studentCourse)
    {
        var result = await context.StudentCourse.AddAsync(studentCourse);
        context.SaveChanges();
        return result==null ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<string>(HttpStatusCode.OK,"Created successfully!");
    }

    public async Task<Response<string>> UpdateStudentCourse(StudentCourse studentCourse)
    {
        var result =  context.StudentCourse.Update(studentCourse);
        context.SaveChanges();
        return result==null ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<string>(HttpStatusCode.OK,"Updated successfully!");
        
        
        
    }

    public async Task<Response<string>> DeleteStudentCourse(int courseId)
    {
        var result =await context.StudentCourse.Where(c => c.Id == courseId).ExecuteDeleteAsync();
        return result==null ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<string>(HttpStatusCode.OK,"Deleted successfully!");
    }
}
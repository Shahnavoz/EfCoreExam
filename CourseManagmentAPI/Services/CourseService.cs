using System.Net;
using CourseManagmentAPI.Data;
using CourseManagmentAPI.Entities;
using CourseManagmentAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MiniLibraryAPI.Responses;

namespace CourseManagmentAPI.Services;

public class CourseService(ApplicationDbContext context):ICourseService
{
    public async Task<List<Course>> GetCoursesAsync()
    {
        return await context.Courses.Include(c=>c.Students).ToListAsync();
    }

    public async Task<Response<Course>> GetCourseAsync(int id)
    {
        var  course = await context.Courses.Include(c => c.Students).Include(c=>c.Modules).FirstOrDefaultAsync(c => c.Id == id);
        return course==null ? new Response<Course>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<Course>(HttpStatusCode.OK,"Found successfully!", course);
    }

    public async Task<Response<string>> CreateCourse(Course course)
    {
        var reuslt = await context.Courses.AddAsync(course);
        context.SaveChanges();
        return reuslt==null ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<string>(HttpStatusCode.OK,"Successfully created successfully!");
    }

    public async Task<Response<string>> UpdateCourse(Course course)
    {
        var result=context.Courses.Update(course);
        context.SaveChanges();
        return result==null ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<string>(HttpStatusCode.OK,"Successfully updated successfully!");
    }

    public async Task<Response<string>> DeleteCourse(int courseId)
    {
        var result = context.Courses.Where(c => c.Id == courseId).ExecuteDelete();
        return result==null ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<string>(HttpStatusCode.OK,"Successfully deleted successfully!");
    }
}
using CourseManagmentAPI.Entities;
using MiniLibraryAPI.Responses;

namespace CourseManagmentAPI.Services.Interfaces;

public interface IStudentService
{
    Task<List<Student>> GetAllStudents();
    Task<Response<Student>> GetStudentById(int studentId);
    Task<Response<string>> CreateStudent(Student student);
    Task<Response<string>> UpdateStudent(Student student);
    Task<Response<string>> DeleteStudent(int studentId);
}
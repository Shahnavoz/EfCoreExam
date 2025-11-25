using CourseManagmentAPI.Entities;
using MiniLibraryAPI.Responses;

namespace CourseManagmentAPI.Services.Interfaces;

public interface IModuleService
{
    Task<List<Module>> GetModulesAsync();
    Task<Response<Module>> GetModuleByIdAsync(int moduleId);
    Task<Response<string>> CreateModuleAsync(Module module);
    Task<Response<string>> UpdateModuleAsync(Module module);
    Task<Response<string>> DeleteModule(int moduleId);
}
using CourseManagmentAPI.Entities;
using CourseManagmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MiniLibraryAPI.Responses;

namespace CourseManagmentAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class ModuleController(IModuleService moduleService):ControllerBase
{
    [HttpGet("GetModules")]
    public async Task<List<Module>> GetModules()
    {
        return await moduleService.GetModulesAsync();
    }

    [HttpGet]
    public async Task<Response<Module>> GetModule(int moduleId)
    {
        return await moduleService.GetModuleByIdAsync(moduleId);
    }

    [HttpPost]
    public async Task<Response<string>> AddModule(Module module)
    {
        return await moduleService.CreateModuleAsync(module);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateModule(Module module)
    {
        return await moduleService.UpdateModuleAsync(module);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteModule(int moduleId)
    {
        return await moduleService.DeleteModule(moduleId);
    }
}
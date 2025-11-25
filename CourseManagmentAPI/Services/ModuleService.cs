using System.Net;
using CourseManagmentAPI.Data;
using CourseManagmentAPI.Entities;
using CourseManagmentAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MiniLibraryAPI.Responses;

namespace CourseManagmentAPI.Services;

public class ModuleService(ApplicationDbContext context):IModuleService
{
    public async Task<List<Module>> GetModulesAsync()
    {
        return await context.Modules.ToListAsync();
    }

    public async Task<Response<Module>> GetModuleByIdAsync(int moduleId)
    {
        var result = await context.Modules.FirstOrDefaultAsync(c => c.Id == moduleId);
        return result==null ? new Response<Module>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<Module>(HttpStatusCode.OK,"Found Successfully!",result);
            
    }

    public async Task<Response<string>> CreateModuleAsync(Module module)
    {
        var result = await context.Modules.AddAsync(module);
        context.SaveChanges();
        return result==null ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<string>(HttpStatusCode.OK,"Created successfully!");
    }

    public async Task<Response<string>> UpdateModuleAsync(Module module)
    {
        var result = context.Modules.Update(module);
         context.SaveChanges();
         return result==null ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
             : new Response<string>(HttpStatusCode.OK,"Updated successfully!");
            
    }

    public async Task<Response<string>> DeleteModule(int moduleId)
    {
        var result = await context.Modules.Where(m => m.Id == moduleId).ExecuteDeleteAsync();
        return result==null ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
            : new Response<string>(HttpStatusCode.OK,"Deleted successfully!");
    }
}
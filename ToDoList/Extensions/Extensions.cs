using ToDoList.Repositories;
using ToDoList.Repositories.Interfaces;
using ToDoList.Services;
using ToDoList.Services.Interfaces;

namespace ToDoList.Extensions;

public static class Extensions
{
    public static IServiceCollection AddToDoListServices(this IServiceCollection services) =>
        services
            .AddScoped<IToDoRepository, ToDoRepository>()
            .AddScoped<IToDoService, ToDoService>();
}
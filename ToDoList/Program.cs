using DotNetEnv;
using Microsoft.OpenApi.Models;
using ToDoList.Extensions;

var builder = WebApplication.CreateBuilder(args);

Env.Load(".env");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDo List", 
        Description = "ToDo List API", 
        Version = "v1"});
});
builder.Services.AddControllers();

builder.Services.AddToDoListServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoAPI v1"));
}

app.UseRouting();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
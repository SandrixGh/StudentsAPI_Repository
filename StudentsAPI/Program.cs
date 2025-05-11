using Microsoft.EntityFrameworkCore;
using StudentsAPI.Application.Services;
using StudentsAPI.Core.Abstractions.StudentAbstractions;
using StudentsAPI.Core.Abstractions.UniversityAbstractions;
using StudentsAPI.DAL;
using StudentsAPI.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<StudentsAPIDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});

builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();

builder.Services.AddScoped<IUniversitiesService, UniversitiesService>();
builder.Services.AddScoped<IUniversitiesRepository, UniversitiesRepository>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

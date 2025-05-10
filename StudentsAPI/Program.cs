using Microsoft.EntityFrameworkCore;
using StudentsAPI.Application.Services;
using StudentsAPI.DAL;
using StudentsAPI.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<StudentsAPIDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLite"));
});

builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();

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

using Day01.Mappings;
using Day01.Persistence;
using Day01.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ITIDbContext>(op =>
    op.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(op => op.AddProfile<MappingConfig>());

builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IStudentService, StudentService>();

string txt = "";
builder.Services.AddCors(options =>
    options.AddPolicy(name: txt,    
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(txt);
app.UseAuthorization();
app.MapControllers();

app.Run();

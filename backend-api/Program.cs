using FileUploaderSample.Filters;
using FileUploaderSample.Infrastructure.EFConfig;
using FileUploaderSample.Infrastructure.Repository.Contracts;
using FileUploaderSample.Infrastructure.Repository.Implementations;
using FileUploaderSample.Services.Contracts;
using FileUploaderSample.Services.Implemenation;
using Microsoft.EntityFrameworkCore;
using FileUploaderSample.Mapping;
using Microsoft.Extensions.Hosting;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) 
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers(config =>
{
    config.Filters.Add<ErrorHandlingFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFileService,FileService>();
builder.Services.AddScoped<IFileRepository,FileRepository>();
builder.Services.AddScoped<IValidationService, ValidationService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevEnv", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseCors("DevEnv");
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

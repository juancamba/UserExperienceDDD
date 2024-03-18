using UserExperience.Application;
using UserExperience.Infrastructure;
using UserExperience.Infra.Persistence;
using UserExperience.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Add services to the container.
// los services locales de cada proyecto (capa) se registran en su propio método de extensión
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);

// politica CROSS ORIGIN
builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder => builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("all");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

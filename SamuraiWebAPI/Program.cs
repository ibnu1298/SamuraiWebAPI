using SamuraiWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using SamuraiWebAPI.Data.DAL;
using SampleWebAPI.Services;
using SampleWebAPI.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Configuration EntityFrameWork DataContext
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("SamuraiConnection")).EnableSensitiveDataLogging());

//Menambahkan Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Inject class DAL
builder.Services.AddScoped<ISamurai, SamuraiDAL>();
builder.Services.AddScoped<ISword, SwordDAL>();
builder.Services.AddScoped<IElement, ElementDAL>();
builder.Services.AddScoped<ITypeSword, TypeSwordDAL>();

// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure DI for application services
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
app.UseMiddleware<JwtMiddleware>();

//app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapControllers();

app.Run();

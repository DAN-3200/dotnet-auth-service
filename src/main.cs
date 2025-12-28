using ConnDB;
using Controllers;
using DTO;
using Microsoft.EntityFrameworkCore;
using Ports;
using repository;
using Usecase;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserDbContext>(options => options.UseNpgsql(
   builder.Configuration.GetConnectionString("Default")
));
builder.Services.AddScoped<IUserPorts,UserRepository>();
builder.Services.AddScoped<UserUsecase>();
builder.Services.AddScoped<UserControllers>();

var app = builder.Build();

app.MapGet("/", () => "Init");
app.MapPost("/user/save", (RegisterDto info, UserControllers usecase) => usecase.SaveUser(info));
app.MapGet("/user/get/{id}", (Guid id, UserControllers usecase) => usecase.GetUserInfo(id));

app.Run();

using ConnDB;
using Controllers;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ports;
using repository;
using Usecase;
using User.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserDbContext>(options => options.UseNpgsql(
   builder.Configuration.GetConnectionString("Default")
));
builder.Services.AddScoped<IPasswordHelper, PasswordHelper>();
builder.Services.AddScoped<IUserPorts,UserRepository>();
builder.Services.AddScoped<UserUsecase>();
builder.Services.AddScoped<UserControllers>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/user/save", (RegisterDto info, UserControllers handle) => handle.SaveUser(info)).Produces<RegisterDto>();
app.MapGet("/user/get/{id}", ([FromRoute] Guid id, UserControllers handle) => handle.GetUserInfo(id)).Produces<Guid>();
app.MapPatch("/user/edit/{id}", ([FromRoute] Guid id, EditDto info, UserControllers handle)=>  handle.EditUser(id, info));
app.MapPatch("/user/deactivate/{id}", ([FromRoute]  Guid id ,UserControllers handle) => handle.DeactivateUser(id));
app.MapDelete("/user/delete/{id}", ([FromRoute] Guid id ,UserControllers handle) => handle.DeletUser(id));

app.Run();

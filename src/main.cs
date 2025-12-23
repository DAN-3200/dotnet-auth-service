using Controllers;
using Entity;
using Usecase;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<>

var app = builder.Build();

var handlers = new UserControllers(new UserUsecase());

app.MapGet("/", () => "Init");
app.MapGet("/user-save", (UserEntity newUser) => handlers.SaveUser(newUser));


app.Run();

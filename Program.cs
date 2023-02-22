using poll_api.Models;
using poll_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Se agrega conexion para base de datos
// builder.Services.AddSqlServer<QuizContext>(builder.Configuration.GetConnectionString("connQuiz"));
builder.Services.AddDbContext<QuizContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Tnyeccion de dependencia HelloWorld
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
// Inyeccion de servicios Custom
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// app.UseWelcomePage();

app.UseTimeMiddleware();

app.MapControllers();

app.Run();

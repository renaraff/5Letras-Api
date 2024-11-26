using Api.Data;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddEntityFrameworkSqlServer()
    //.AddDbContext<Contexto>(
  //  options => options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=SP-1491035\\SQLSENAI;Initial Catalog = 5Letras-Banco;Integrated Security = True;TrustServerCertificate = True"))
  //  );
builder.Services.AddDbContext<Contexto> //Renara
    (options => options.UseSqlServer("Data Source=SP-1491035\\SQLSENAI;Initial Catalog = 5Letras-Banco;Integrated Security = True;TrustServerCertificate = True"));
//var app = builder.Build();


builder.Services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
builder.Services.AddScoped<IComentarioRepositorio, ComentarioRepositorio>();
builder.Services.AddScoped<IConteudoRepositorio, ConteudoRepositorio>();
builder.Services.AddScoped<IDuvidaRepositorio, DuvidaRepositorio>();
builder.Services.AddScoped<IMateriasRepositorio, MateriasRepositorio>();
builder.Services.AddScoped<IProfessorRepositorio, ProfessorRepositorio>();
builder.Services.AddScoped<IAuthRepositorio, AuthRepositorio>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();


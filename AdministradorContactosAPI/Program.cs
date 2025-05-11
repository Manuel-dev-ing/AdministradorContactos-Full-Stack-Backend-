using AdministradorContactosAPI.Entidades;
using AdministradorContactosAPI.Servicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// area de Servicios
builder.Services.AddControllers().AddJsonOptions(opciones =>
opciones.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles); // habilita la funcionalidad de controladores

builder.Services.AddTransient<IRepositorioContactos, RepositorioContactos>();
builder.Services.AddTransient<IRepositorioGrupo, RepositorioGrupos>();

builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
{
    opciones.UseSqlServer("name=DefaultConnection");

});

builder.Services.AddCors(options =>
{
    options.AddPolicy("nuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });

});


var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapControllers();// 

app.UseCors("nuevaPolitica");

app.Run();

using MagicVilla;
using MagicVilla.Data;
using MagicVilla.Repositorio;
using MagicVilla.Repositorio.IRepositorio;
using MagicVilla.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(MappingConfing));

// # Titulo  :   Agregar Interfaz Villa Repositorio 2
// # Minuto  :   3:16:53
builder.Services.AddScoped<IVillaRepositorio, VillaRepositorio>();
builder.Services.AddScoped<INumeroVillaRepositorio, NumeroVillaRepositorio>();
// # Se aplica tabla Usuario para crear seguridad
builder.Services.AddScoped<IUsuarioRepositorio,UsuarioRepositorio>();
builder.Services.AddScoped<IAutorizacionService, AutorizacionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

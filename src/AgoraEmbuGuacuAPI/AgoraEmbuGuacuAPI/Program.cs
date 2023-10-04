using AgoraEmbuGuacuAPI.Context;
using AgoraEmbuGuacuAPI.Interfaces;
using AgoraEmbuGuacuAPI.Repository;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
var connectionString = builder.Configuration.GetConnectionString("ConexaoPadrao");

builder.Services.AddDbContext<AgoraContext>(options =>
    options.UseMySql(connectionString,
    ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IDenunciaRepository, DenunciaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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

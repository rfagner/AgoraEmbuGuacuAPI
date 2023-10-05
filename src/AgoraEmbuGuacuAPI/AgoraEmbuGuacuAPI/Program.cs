using AgoraEmbuGuacuAPI.Context;
using AgoraEmbuGuacuAPI.Interfaces;
using AgoraEmbuGuacuAPI.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
var connectionString = builder.Configuration.GetConnectionString("ConexaoPadrao");

builder.Services.AddDbContext<AgoraContext>(options =>
    options.UseMySql(connectionString,
    ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("agora-embu-guacu-2023-@#$-chave-de-authenticacao")),
        ClockSkew = TimeSpan.FromMinutes(30),
        ValidIssuer = "agora.webAPI",
        ValidAudience = "agora.webAPI"
    };
});

builder.Services.AddScoped<IDenunciaRepository, DenunciaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Configurando o Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AgoraEmbuGuacuAPI", Version = "v1" });

    // Configurando o esquema de segurança Bearer
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });

    // Adicionando o esquema de segurança aos requerimentos de autorização
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddCors(policyBuilder =>
                policyBuilder.AddDefaultPolicy(policy =>
                policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin())
            );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

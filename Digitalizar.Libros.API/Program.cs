using Digitalizar.Libros.BLL.Contrato;
using Digitalizar.Libros.BLL.Services;
using Digitalizar.Libros.DAL.DbContext;
using Digitalizar.Libros.DAL.Execptions;
using Digitalizar.Libros.DAL.Repository.Contrato;
using Digitalizar.Libros.DAL.Repository.Implementacion;
using Digitalizar.Libros.Models.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cadena de Conexion
builder.Services.AddDbContext<DigitalizarDbContext>(option=>

    option.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"), p=> p.MigrationsAssembly("Digitalizar.Libros.API"))

);

//Simplificar password alfanumerico
builder.Services.AddIdentity<Usuario, IdentityRole>(option => { option.Password.RequireNonAlphanumeric = false; option.User.RequireUniqueEmail = true; }).AddEntityFrameworkStores<DigitalizarDbContext>().AddDefaultTokenProviders();

//Declaracion de los Cors

var MisReglasCors = "ReglasCors";
builder.Services.AddCors(opt =>

    opt.AddPolicy(name: MisReglasCors, builder=>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    })

);

//Configuracion del tocken
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["llaveJwt"])),
        ClockSkew= TimeSpan.Zero
    }
);

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {

        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header

    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {

            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                Type  = ReferenceType.SecurityScheme,
                Id = "Bearer"

                }
            },

            new string[]{}

        }

    });


});


//Inyeccion de Dependencias
// Data Sedder
builder.Services.AddScoped<IDataSeeder, DataSeeder>();

//Usuarios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

//Token
builder.Services.AddScoped<ITokenService, TokenService>();

//Categorias
builder.Services.AddScoped<IGenericRepository<Categoria>, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

//Editorial
builder.Services.AddScoped<IGenericRepository<Editorial>, EditorialRepository>();
builder.Services.AddScoped<IEditorialService, EditorialService>();

//Autores
builder.Services.AddScoped<IGenericRepository<Autor>, AutorRepository>();
builder.Services.AddScoped<IAutorService, AutorService>();

//Libros
builder.Services.AddScoped<IGenericRepository<Libro>, LibroRepository>();
builder.Services.AddScoped<ILibroService, LibroService>();

//Email
builder.Services.AddScoped<IEmailService, EmailService>();


var app = builder.Build();

//Crear Usuario y Roles Por defecto

using (var scope = app.Services.CreateScope()) 
{ 
    var service = scope.ServiceProvider;
    try 
    { 
        var dataSeeder = service.GetRequiredService<IDataSeeder>();
        
        await dataSeeder.CrearRoles();
        
        await dataSeeder.CrearUsuarioAdmin();

    }catch (Exception ex) 
    {
        throw;
    }

}


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }


app.UseCors(MisReglasCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

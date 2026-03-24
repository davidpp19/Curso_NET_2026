//Se pone la URL del API para que el CRUD sepa a donde hacer las peticiones. Se hace en el Program.cs para que quede centralizado y no haya que ponerlo en cada controlador.
using API.Consumer;
using Libreria.Servicios;
using Libreria.Servicios.Interfaces;
using LibreriaModelo;
CRUD<Pais>.EndPoint = "https://curso-net-2026.onrender.com/api/Paises";
CRUD<Autor>.EndPoint = "https://curso-net-2026.onrender.com/api/Autores";
CRUD<Biblioteca>.EndPoint = "https://curso-net-2026.onrender.com/api/Bibliotecas";
CRUD<Cliente>.EndPoint = "https://curso-net-2026.onrender.com/api/Clientes";
CRUD<Libro>.EndPoint = "https://curso-net-2026.onrender.com/api/Libros";
CRUD<Prestamo>.EndPoint = "https://curso-net-2026.onrender.com/api/Prestamos";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddAuthentication("Cookies") //cokies
                .AddCookie("Cookies", options =>
                {
                    options.LoginPath = "/Account/Index"; // Ruta de inicio de sesión


                });
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();

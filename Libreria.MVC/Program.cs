//Se pone la URL del API para que el CRUD sepa a donde hacer las peticiones. Se hace en el Program.cs para que quede centralizado y no haya que ponerlo en cada controlador.
using API.Consumer;
using LibreriaModelo;
CRUD<Pais>.EndPoint = "https://localhost:7278/api/Paises";
CRUD<Autor>.EndPoint = "https://localhost:7278/api/Autores";
CRUD<Biblioteca>.EndPoint = "https://localhost:7278/api/Bibliotecas";
CRUD<Cliente>.EndPoint = "https://localhost:7278/api/Clientes";
CRUD<Libro>.EndPoint = "https://localhost:7278/api/Libros";
CRUD<Prestamo>.EndPoint = "https://localhost:7278/api/Prestamos";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

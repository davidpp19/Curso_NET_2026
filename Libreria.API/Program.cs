using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Libreria.API.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LibreriaAPIContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("LibreriaAPIContext") ?? throw new InvalidOperationException("Connection string 'LibreriaAPIContext' not found.")));

// Add services to the container.
//Se indica que en el AddController vamos a serializar.
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

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

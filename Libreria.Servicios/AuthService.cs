using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using API.Consumer;
using LibreriaModelo;   
using Libreria.Servicios.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;


namespace Libreria.Servicios
{
    public class AuthService : Interfaces.IAuthService
    {
       private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> Login(string email, string password)
        {
            var usuarios = CRUD<Cliente>.GetAll();

            foreach (var usuario in usuarios)
            {
                if (usuario.Correo_Cliente == email)
                {
                    //BCrypt compara el texto plano con el Hash almacenado en la base de datos
                    if (BCrypt.Net.BCrypt.Verify(password, usuario.Contrasena_Cliente))
                    {
                        var datosUsuario = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, usuario.Nombre_Cliente),
                            new Claim(ClaimTypes.Email, usuario.Correo_Cliente),
                            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
                        };

                        var credenciaDigital = new ClaimsIdentity(datosUsuario, "Cookies");
                        var usuarioAutenticado = new ClaimsPrincipal(credenciaDigital);
                        await _httpContextAccessor.HttpContext.SignInAsync("Cookies", usuarioAutenticado);
                        return true;
                    }
                }
            }
            return false;
        }

        public async Task<bool> Register(
         string nombre,
         string email,
         string nombreUsuario,
         string password)
        {
            //Verificamos duplicados con endpoints específicos
            var usuarioExistente = CRUD<Cliente>.GetAll()
                 .FirstOrDefault(u => u.Correo_Cliente == email);

            if (usuarioExistente != null)
            {
                Console.WriteLine("Error: El correo ya está registrado.");
                return false;
            }

            try
            {
                //CREACIÓN DEL OBJETO USUARIO CON HASH SEGURIDAD
                var nuevoUsuario = new Cliente
                {
                    Id = 0,
                    Nombre_Cliente = nombre,
                    Correo_Cliente = email,
                    Nombre_Usuario = nombreUsuario,
                    Contrasena_Cliente = password
                };

                CRUD<Cliente>.Create(nuevoUsuario);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar usuario: {ex.Message}");
                return false;
            }
        }
    }
}

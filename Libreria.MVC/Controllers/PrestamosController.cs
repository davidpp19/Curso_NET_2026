using API.Consumer;
using LibreriaModelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.MVC.Controllers
{
    public class PrestamosController : Controller
    {
        // GET: PrestamosController
        public ActionResult Index()
        {
            var prestamos = CRUD<Prestamo>.GetAll();
            return View(prestamos);
        }

        // GET: PrestamosController/Details/5
        public ActionResult Details(int id)
        {
            var prestamo = CRUD<Prestamo>.GetById(id);
            if(prestamo == null)
            {
                return NotFound();
            }   
            return View(prestamo);
        }
        //Método interno para obtener los libros, es un GET LIBROS.
        private List<SelectListItem> GetLibros()
        {
            var libros = CRUD<Libro>.GetAll();
            return libros.Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Titulo_Libro
            }).ToList();
        }

        //Método interno para obtener los clientes, es un GET CLIENTES.
        private List<SelectListItem> GetClientes()
        {
            var clientes = CRUD<Cliente>.GetAll();
            return clientes.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nombre_Cliente
            }).ToList();
        }

        // GET: PrestamosController/Create
        public ActionResult Create()
        {
            ViewBag.Libros = GetLibros();
            ViewBag.Clientes = GetClientes();
            return View();
        }

        // POST: PrestamosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prestamo prestamo)
        {
            try
            {
                CRUD<Prestamo>.Create(prestamo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", ex.Message);
                return View(prestamo);
            }
        }

        // GET: PrestamosController/Edit/5
        public ActionResult Edit(int id)
        {
            var prestamo = CRUD<Prestamo>.GetById(id);
            ViewBag.Libros = GetLibros();
            ViewBag.Clientes = GetClientes();
            if(prestamo == null)
            {
                return NotFound();
            }
            return View(prestamo);
        }

        // POST: PrestamosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Prestamo prestamo)
        {
            try
            {
                CRUD<Prestamo>.Update(id, prestamo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", ex.Message);
                return View(prestamo);
            }
        }

        // GET: PrestamosController/Delete/5
        public ActionResult Delete(int id)
        {
            var prestamo = CRUD<Prestamo>.GetById(id);
            if(prestamo == null)
            {
                return NotFound();
            }
            return View(prestamo);
        }

        // POST: PrestamosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Prestamo prestamo)
        {
            try
            {
                CRUD<Prestamo>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", ex.Message);
                return View(prestamo);
            }
        }
    }
}

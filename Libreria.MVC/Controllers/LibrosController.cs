using API.Consumer;
using LibreriaModelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.MVC.Controllers
{
    public class LibrosController : Controller
    {
        // GET: LibrosController
        public ActionResult Index()
        {
            var libros = CRUD<Libro>.GetAll();
            return View(libros);
        }

        // GET: LibrosController/Details/5
        public ActionResult Details(int id)
        {
            var libro = CRUD<Libro>.GetById(id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        //Método interno para obtener las bibliotecas, es un GET BIBLIOTECAS.
        private List<SelectListItem> GetBibliotecas()
        {
            var bibliotecas = CRUD<Biblioteca>.GetAll();
            return bibliotecas.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Nombre_Biblioteca
            }).ToList();
        }

        //Método interno para obtener los autores, es un GET AUTORES.
        private List<SelectListItem> GetAutores()
        {
            var autores = CRUD<Autor>.GetAll();
            return autores.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = $"{a.Nombres_Autor} {a.Apellidos_Autor}"
            }).ToList();
        }

        // GET: LibrosController/Create
        public ActionResult Create()
        {
            ViewBag.Autores = GetAutores();
            ViewBag.Bibliotecas = GetBibliotecas();
            return View();
        }

        // POST: LibrosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Libro libro)
        {
            try
            {
                CRUD<Libro>.Create(libro);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(libro);
            }
        }

        // GET: LibrosController/Edit/5
        public ActionResult Edit(int id)
        {
            var libro = CRUD<Libro>.GetById(id);
            ViewBag.Autores = GetAutores();
            ViewBag.Bibliotecas = GetBibliotecas();

            if(libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // POST: LibrosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Libro libro)
        {
            try
            {
                CRUD<Libro>.Update(id, libro);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(libro);
            }
        }

        // GET: LibrosController/Delete/5
        public ActionResult Delete(int id)
        {
            var libro = CRUD<Libro>.GetById(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // POST: LibrosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Libro libro)
        {
            try
            {
                CRUD<Libro>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", ex.Message);
                return View(libro);
            }
        }
    }
}

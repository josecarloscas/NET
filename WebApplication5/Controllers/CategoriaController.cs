using Microsoft.AspNetCore.Mvc;
using WebApplication5.Datos;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _db; 

        public CategoriaController (ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Categoria> lista = _db.Categoria;

            return View(lista);
        }

        //Crear Categoria
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Categoria categoria)
        {

            if (ModelState.IsValid)
            {
                _db.Categoria.Add(categoria);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //Get Editar
        public IActionResult Editar(int? Id)
        {
            if(Id==null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categoria.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Categoria categoria)
        {

            if (ModelState.IsValid)
            {
                _db.Categoria.Update(categoria);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //Get Eliminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categoria.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Categoria categoria)
        {

            if (categoria == null)
            {
                return NotFound();
            }
            _db.Categoria.Remove(categoria);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

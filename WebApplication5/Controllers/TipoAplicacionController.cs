using Microsoft.AspNetCore.Mvc;
using WebApplication5.Datos;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class TipoAplicacionController : Controller
    {
        private readonly ApplicationDbContext _db; 

        public TipoAplicacionController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<TipoAplicacion> lista = _db.TipoAplicacion;

            return View(lista);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(TipoAplicacion tipoAplicacion)
        {
            _db.TipoAplicacion.Add(tipoAplicacion);
            _db.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }
    }
}

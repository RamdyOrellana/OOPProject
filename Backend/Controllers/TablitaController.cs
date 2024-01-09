using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Backend.Controllers
{
    public class TablitaController : Controller
{
    private readonly EmpleadosContext _context;

    public TablitaController(EmpleadosContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string buscar, int pagina = 1, int cantidadRegistros = 10)
    {
        var busqueda = from tablita in _context.Registros select tablita;

        if (!String.IsNullOrEmpty(buscar))
        {
            busqueda = busqueda.Where(s => s.Nombres.Contains(buscar) || s.NumeroDocumento.ToString().Contains(buscar));
        }

        var resultadoPaginado = await busqueda.Skip((pagina - 1) * cantidadRegistros).Take(cantidadRegistros).ToListAsync();

        ViewBag.PaginaActual = pagina;
        ViewBag.TotalPaginas = CalcularTotalPaginas(busqueda.Count(), cantidadRegistros); // Debes implementar esta función para calcular el total de páginas

        return View(resultadoPaginado);
    }

        public ActionResult Vista(int pagina = 1, int cantidadRegistros = 10)
        {
            ViewBag.Paises = new SelectList(_context.Pais, "PaisId", "Nombre");
            ViewBag.Areas = new SelectList(new List<Area>(), "AreaId", "Nombre");
            ViewBag.SubAreas = new SelectList(new List<SubArea>(), "SubAreaId", "Nombre");

            var resultado = _context.Database.SqlQueryRaw<Registro>("EXEC dbo.fnPaginar @pagina, @cantidadReg",
                new SqlParameter("@pagina", pagina),
                new SqlParameter("@cantidadReg", cantidadRegistros)
            ).ToList();

            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = CalcularTotalPaginas(4,10); 

            return PartialView("_VistaParcial", resultado);
        }

        
        private int CalcularTotalPaginas(int totalRegistros, int cantidadRegistrosPorPagina)
    {
        return (int)Math.Ceiling((double)totalRegistros / cantidadRegistrosPorPagina);
    }
}
}

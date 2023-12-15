using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.Domain.Request;
using web.Repository;

namespace web.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //api/director


    public class DirectorController : ControllerBase
    {
        private readonly IMDBContext _context;
        public DirectorController(IMDBContext context)
        {
            _context = context;
        }


        [HttpGet]

        public IActionResult GetDirectores([FromQuery] GetDirectoresRequest request)
        {


            //var result = _context.Directores.ToList();

            //paginado
            var skip = request.skip;
            var take = request.take;

            var result = _context.Directores.Skip(skip).Take(take);
            var count = _context.Directores.Count();
            return Ok(new
            {
                Datos = result,
                Count = count
            });
        }
        [HttpGet("{id}")]

        //consultar por id del productor
        public IActionResult GetDirectorById([FromRoute] int id)
        {
            //una de las maneras de consultar usando el where
            //var result = _context.Directores.Where(w=>w.IdDirector == id).FirstOrDefault();
            var result = _context.Directores.FirstOrDefault(m => m.IdDirector == id);
            if (result == null) return NotFound(new { Error = $"No se encontro el director con el id {id}" });

            return Ok(result);
        }

        [HttpGet("Peliculas")]

        //consultar por id director y su pelicula
        public IActionResult GetPeliculasByDirectoriD([FromQuery] int IdDirector)
        {
            var result = _context.Directores.Where(w => w.IdDirector == IdDirector)
                                            .Include(i => i.Peliculas)
                                            .ToList();
            if (result.Count == 0) return NotFound(new { Error = $"No se encontraron resultados para el id {IdDirector}" });
            
            return Ok(result);
        }


        [HttpGet("Año_Pelciulas")]

        //peliculas cuyo año sea mayor a 1995
        public IActionResult GetPeliculaFromYear([FromQuery] int Idpelicula)
        {
            var result = _context.Peliculas.Where(w => w.IdPelicula == Idpelicula)
                                           .Where(f =>f.AñoEstreno > 1995)
                                           .ToList();
                                           

            if (result.Count == 0) return NotFound(new
            {
                Error = $"El id {Idpelicula} seleccionado no corresponde a un año de estrono superior a 1995"
            });
            return Ok(result);
        }

        //Todas las peliculas por año seleccionado 
        [HttpGet ("AllPeliculas_ForYear")]

        public IActionResult GetAllPeliculasForYear([FromQuery]int year)
        {
            var result = _context.Peliculas.Where(w=>w.AñoEstreno == year).ToList();

            if (result.Count == 0) return NotFound(new { Error =$"El año seleccionado no posee estrenos de peliculas"})

        ;   return Ok(result);

            
        }

        //filtrar por genero

        /*[HttpGet ("Genero")]

        public IActionResult GetAllGeneros([FromQuery] GetAllGeneros request)
        {
     
            var result = _context.Peliculas.Where(w => w.PeliculasGeneros == request).ToList();

            if (result == null) return NotFound(new { Error = $"El genero {request.Genero}" });

             return Ok(result);

        }*/ //esta mal hay que resolver  




    }
}

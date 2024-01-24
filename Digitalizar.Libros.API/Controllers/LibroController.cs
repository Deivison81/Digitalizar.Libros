using Digitalizar.Libros.BLL.Contrato;
using Digitalizar.Libros.BLL.Services;
using Digitalizar.Libros.DAL.Execptions;
using Digitalizar.Libros.Models.Entidades;
using Digitalizar.Libros.Models.VModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digitalizar.Libros.API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpGet("Buscar Libros por ID")]
        public async Task<ActionResult<VMLibro>> Listar(int id)
        {
            try
            {
                var Libro = await _libroService.Obtener(id);

                return Ok(Libro);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("Buscar Libros por categoria")]
        public async Task<ActionResult<VMLibro>> ListarxCategoria (int id)
        {
            try
            {
                var Libro = await _libroService.ObtenerxCategoria(id);

                return Ok(Libro);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("Buscar Libros por Autor")]
        public async Task<ActionResult<VMLibro>> ListarxAutor(int id)
        {
            try
            {
                var Libro = await _libroService.ObtenerxAutor(id);

                return Ok(Libro);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpGet("Buscar Libros")]
        public async Task<ActionResult<VMLibro>> ListarTotal()
        {

            try
            {
                var Libro = await _libroService.ObtenerTodos();

                return Ok(Libro);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Registrar([FromBody]VMLibro modelo)
        {
            try
            {
                Libro newModelo = new Libro() 
                { 
                    Nombre = modelo.Nombre,
                    CategoriaID = modelo.CategoriaID,
                    EditorialID = modelo.EditorialID,
                    AutorID = modelo.AutorID,
                    ruta = modelo.ruta,
                    nombre_archivo = modelo.nombre_archivo

                };

                var libro = await _libroService.Insertar(newModelo);

                return Ok(libro);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Actualizar([FromBody] VMLibro modelo)
        {
            try
            {
                int id = modelo.ID;
                Libro newModelo = new Libro()
                {
                    Nombre = modelo.Nombre,
                    CategoriaID = modelo.CategoriaID,
                    EditorialID = modelo.EditorialID,
                    AutorID = modelo.AutorID,
                    ruta = modelo.ruta,
                    nombre_archivo = modelo.nombre_archivo
                };

                var Libro = await _libroService.Actualizar(id, newModelo);

                return Ok(Libro);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var resultado = await _libroService.Eliminar(id);

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}

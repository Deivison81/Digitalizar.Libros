using Digitalizar.Libros.BLL.Contrato;
using Digitalizar.Libros.BLL.Services;
using Digitalizar.Libros.DAL.Execptions;
using Digitalizar.Libros.Models.Entidades;
using Digitalizar.Libros.Models.VModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digitalizar.Libros.API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet("Buscar Autor por ID")]
        public async Task<ActionResult<VMAutor>> Listar(int id)
        {
            try
            {
                var autor = await _autorService.Obtener(id);

                return Ok(autor);
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

        [HttpGet("Buscar Autores")]
        public async Task<ActionResult<VMAutor>> ListarTotal()
        {

            try
            {
                var autor = await _autorService.ObtenerTodos();

                return Ok(autor);
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult<VMAutor>> Registrar(Autor modelo)
        {
            try
            {
                var autor = await _autorService.Insertar(modelo);

                return Ok(autor);
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<ActionResult<VMAutor>> Actualizar(int id, Autor modelo)
        {
            try
            {
                var autor = await _autorService.Actualizar(id, modelo);

                return Ok(autor);
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var resultado = await _autorService.Eliminar(id);

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

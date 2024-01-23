using Digitalizar.Libros.BLL.Contrato;
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
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialService _editorialService;

        public EditorialController(IEditorialService editorialService)
        {
            _editorialService = editorialService;
        }

        [HttpGet("Buscar Editorial por ID")]
        public async Task<ActionResult<VMEditorial>> Listar(int id)
        {
            try
            {
                var Editorial = await _editorialService.Obtener(id);

                return Ok(Editorial);
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

        [HttpGet("Buscar Editorial")]
        public async Task<ActionResult<VMEditorial>> ListarTotal()
        {

            try
            {
                var Editorial = await _editorialService.ObtenerTodos();

                return Ok(Editorial);
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
        public async Task<ActionResult<VMEditorial>> Registrar(Editorial modelo)
        {
            try
            {
                var Editorial = await _editorialService.Insertar(modelo);

                return Ok(Editorial);
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
        public async Task<ActionResult<VMEditorial>> Actualizar(Editorial modelo)
        {
            try
            {
                var Editorial = await _editorialService.Actualizar(modelo);

                return Ok(Editorial);
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
                var resultado = await _editorialService.Eliminar(id);

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

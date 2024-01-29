using Digitalizar.Libros.BLL.Contrato;
using Digitalizar.Libros.DAL.Execptions;
using Digitalizar.Libros.Models.Entidades;
using Digitalizar.Libros.Models.VModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Digitalizar.Libros.API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("Buscar Categoria por ID")]
        public async Task<ActionResult<VMCategoria>> Listar(int id) 
        {
            try
            {
                var categoria = await _categoriaService.Obtener(id);

                return Ok(categoria);
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

        [HttpGet("Buscar Categorias")]
        public async Task<ActionResult<VMCategoria>> ListarTotal()
        {

            try
            {
                var categoria = await _categoriaService.ObtenerTodos();

               

                return Ok(categoria);
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
        public async Task<ActionResult<VMCategoria>> Registrar(Categoria modelo) 
        {
            try
            {
                var categoria = await _categoriaService.Insertar(modelo);

                return Ok(categoria);
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
        public async Task<ActionResult<VMCategoria>> Actualizar(int id, Categoria modelo)
        {
            try
            {
                var categoria = await _categoriaService.Actualizar(id, modelo);

                return Ok(categoria);
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
                var resultado = await _categoriaService.Eliminar(id);

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

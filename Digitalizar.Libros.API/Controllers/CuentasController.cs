using Digitalizar.Libros.BLL.Contrato;
using Digitalizar.Libros.Models.Entidades;
using Digitalizar.Libros.Models.VModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Digitalizar.Libros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
       private readonly IUsuarioService _usuarioService;
       private readonly SignInManager<Usuario> _signInManager;
       private readonly ITokenService _tokenService;

        public CuentasController(IUsuarioService usuarioService, SignInManager<Usuario> signInManager, ITokenService tokenService)
        {
            _usuarioService = usuarioService;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult<RespuestaAuth>> Registrar([FromBody]VMCredenciales modelo) 
        {
            try 
            {
                bool Resultado = await _usuarioService.Registrar(modelo);

                if (!Resultado) 
                {
                    return BadRequest("No se Pudo Agregar el Usuario verifique sus datos");
                }

                var token = await _tokenService.GenerarToken(modelo.Email, 1);

                RespuestaAuth respuestaAuth = new RespuestaAuth { 
                    Email = modelo.Email,
                    Token= token,
                };

                return Ok(respuestaAuth);

            }catch(Exception) 
            {
                return StatusCode(500, "Error interno del servidor");
            }
        
        }

        [HttpPost("Login")]
        public async Task<ActionResult<RespuestaAuth>> Login([FromBody]VMCredenciales CredencialesUsuario)
        {
            try 
            {
                var result = await _signInManager.PasswordSignInAsync(CredencialesUsuario.Email, CredencialesUsuario.Password, isPersistent: false, lockoutOnFailure: false);

                if (!result.Succeeded) return BadRequest("Sus Credenciales son Incorrectas");

                return Ok(await _usuarioService.GetCredencialesAsync(CredencialesUsuario.Email));
                
            }catch(Exception)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }

    }
}

using Digitalizar.Libros.BLL.Contrato;
using Digitalizar.Libros.Models.Entidades;
using Digitalizar.Libros.Models.VModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Digitalizar.Libros.API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
       private readonly IUsuarioService _usuarioService;
       private readonly SignInManager<Usuario> _signInManager;
       private readonly ITokenService _tokenService;
       private readonly IEmailService _emailService;

        public CuentasController(IUsuarioService usuarioService, SignInManager<Usuario> signInManager, ITokenService tokenService, IEmailService emailService)
        {
            _usuarioService = usuarioService;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _emailService = emailService;
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

                VMEmail request = new VMEmail()
                {
                    Para = modelo.Email,
                    Asunto = "Registro exitoso",
                    Contenido = "su registro ha sido efectuado satisfactoriamente"


                };

                 _emailService.SendEmail(request);
                
                return Ok(Resultado);

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

                //var token = await _tokenService.GenerarToken(CredencialesUsuario.Email, 1);
                /*
                RespuestaAuth respuestaAuth = new RespuestaAuth { 
                  Email = CredencialesUsuario.Email,
                  Token= token,
                };*/

                return Ok(await _usuarioService.GetCredencialesAsync(CredencialesUsuario.Email));
            
            }catch(Exception ex)
            {
                //return StatusCode(500, "Error interno del servidor");
                return Ok(ex.Message);
            }
        }

    }
}

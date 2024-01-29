using Digitalizar.Libros.BLL.Contrato;
using Digitalizar.Libros.DAL.Repository.Contrato;
using Digitalizar.Libros.Models.Entidades;
using Digitalizar.Libros.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.BLL.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _RegistrarRepo;
        private readonly IEmailService _EmailRepo;
        private readonly ITokenService _TokenService;
        

        public UsuarioService(IUsuarioRepository registrarRepo, IEmailService EmailRepo, ITokenService TokenService)
        {
            _RegistrarRepo = registrarRepo;
            _TokenService = TokenService;
            _EmailRepo = EmailRepo;
           
        }

        public async Task<bool> Registrar(VMCredenciales modelo)
        {
            Usuario Usuario = new Usuario()
            {
                UserName = modelo.Email,
                
                Email = modelo.Email,
                
                FechaCreacion = DateTime.Now,
            };

            var registro = await _RegistrarRepo.Registrar(Usuario, modelo.Password);


            //await _EmailRepo.EnviarEmailAsync(Usuario.Email, "Registro exitoso","Su registro se a realizado satisfactoriamente");

            VMEmail request = new VMEmail()
            {
                Para = modelo.Email, 
                Asunto = "Registro Exitoso",
                Contenido= "Su registro se a realizado satisfactoriamente"


            };

            _EmailRepo.SendEmail(request);

            return registro;
        }

        public async Task<RespuestaAuth> GetCredencialesAsync(string email)
        {
            try 
            {

                var usuario = await _RegistrarRepo.GetCredencialesAsync(email);
                          
                var token = _TokenService.GenerarToken(email, 1);

                return new RespuestaAuth()
                {
                    Email = usuario.Email,

                    Token = token.Result
                };

            }catch (Exception) 
            {
                throw;
            }
        }
    }
}

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
        private readonly ITokenService _TokenService;
        

        public UsuarioService(IUsuarioRepository registrarRepo, ITokenService TokenService)
        {
            _RegistrarRepo = registrarRepo;
            _TokenService = TokenService;
           
        }

        public async Task<bool> Registrar(VMCredenciales modelo)
        {
            Usuario Usuario = new Usuario()
            {
                UserName = modelo.Email,
                
                Email = modelo.Email,
                
                FechaCreacion = DateTime.Now,
            };

            return await _RegistrarRepo.Registrar(Usuario, modelo.Password);
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

using Digitalizar.Libros.DAL.DbContext;
using Digitalizar.Libros.DAL.Execptions;
using Digitalizar.Libros.DAL.Repository.Contrato;
using Digitalizar.Libros.Models.Entidades;
using Digitalizar.Libros.Models.VModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.DAL.Repository.Implementacion
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly UserManager<Usuario> userManager;
        private readonly DigitalizarDbContext _dbcontext;

        public UsuarioRepository(UserManager<Usuario> userManager, DigitalizarDbContext dbcontext)
        {
            this.userManager = userManager;
            _dbcontext = dbcontext;
        }


        public async Task<bool> Registrar(Usuario modelo, string password)
        {
            var trasaction = await _dbcontext.Database.BeginTransactionAsync();
            try
            {
                var resultado = await userManager.CreateAsync(modelo, password);
                if (!resultado.Succeeded) return false;
                var resultadoRol = await userManager.AddToRoleAsync(modelo, "usuario");
                if (!resultadoRol.Succeeded)
                {

                    await trasaction.RollbackAsync();
                    return false;
                }
                await trasaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await trasaction.RollbackAsync();
                return false;
            }
        }

        public async Task<Usuario> GetCredencialesAsync(string email)
        {
            try
            { 
                var user = await _dbcontext.Users.Where(user=> user.Email == email).FirstOrDefaultAsync();

                if (user == null) throw new NotFoundException();

                return user;
            }
            catch (Exception) 
            {
                throw;
            }
        }
    }
}

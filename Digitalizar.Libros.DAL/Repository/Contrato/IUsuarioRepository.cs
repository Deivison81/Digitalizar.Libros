using Digitalizar.Libros.Models.Entidades;
using Digitalizar.Libros.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.DAL.Repository.Contrato
{
    public interface IUsuarioRepository
    {
        Task<bool> Registrar(Usuario modelo, string password);

        Task<Usuario> GetCredencialesAsync(string email);


    }
}

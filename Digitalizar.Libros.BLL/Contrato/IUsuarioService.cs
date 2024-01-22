using Digitalizar.Libros.Models.Entidades;
using Digitalizar.Libros.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.BLL.Contrato
{
    public interface IUsuarioService
    {
        Task<bool> Registrar(VMCredenciales modelo);

        Task<RespuestaAuth>GetCredencialesAsync(string email);
    }
}

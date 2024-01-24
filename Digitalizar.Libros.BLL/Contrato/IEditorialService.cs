using Digitalizar.Libros.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.BLL.Contrato
{
    public interface IEditorialService
    {
        Task<bool> Insertar(Editorial modelo);

        Task<bool> Actualizar(int id, Editorial modelo);

        Task<bool> Eliminar(int id);

        Task<Editorial> Obtener(int id);

        Task<Editorial> Obtenerxnombre(string nombre);

        Task<IQueryable<Editorial>> ObtenerTodos();
    }
}

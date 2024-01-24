using Digitalizar.Libros.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.BLL.Contrato
{
    public interface IAutorService
    {
        Task<bool> Insertar(Autor modelo);

        Task<bool> Actualizar(int id, Autor modelo);

        Task<bool> Eliminar(int id);

        Task<Autor> Obtener(int id);

        Task<Autor> Obtenerxnombre(string nombre);

        Task<IQueryable<Autor>> ObtenerTodos();
    }
}

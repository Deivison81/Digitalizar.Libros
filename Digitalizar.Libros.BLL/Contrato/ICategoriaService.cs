using Digitalizar.Libros.Models.Entidades;
using Digitalizar.Libros.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.BLL.Contrato
{
    public interface ICategoriaService
    {
        Task<bool> Insertar(Categoria modelo);

        Task<bool> Actualizar(int id, Categoria modelo);

        Task<bool> Eliminar(int id);

        Task<Categoria> Obtener(int id);

        Task<Categoria> Obtenerxnombre(string nombre);

        Task<IQueryable<Categoria>> ObtenerTodos();

        
    }
}

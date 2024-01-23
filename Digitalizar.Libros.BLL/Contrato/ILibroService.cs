using Digitalizar.Libros.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.BLL.Contrato
{
    public interface ILibroService
    {
        Task<bool> Insertar(Libro modelo);

        Task<bool> Actualizar(Libro modelo);

        Task<bool> Eliminar(int id);

        Task<Libro> Obtener(int id);

        Task<Libro> Obtenerxnombre(string nombre);

        Task<IQueryable<Libro>> ObtenerTodos();

        Task<IEnumerable<Libro>> ObtenerxAutor(int AutorID);

        Task<IEnumerable<Libro>> ObtenerxCategoria(int CetegoriaID);

    }
}

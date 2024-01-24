using Digitalizar.Libros.BLL.Contrato;
using Digitalizar.Libros.DAL.Repository.Contrato;
using Digitalizar.Libros.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Digitalizar.Libros.BLL.Services
{
    public class LibroService: ILibroService
    {
        private readonly IGenericRepository<Libro> _LibroRepo;

        public LibroService(IGenericRepository<Libro> libroRepo)
        {
            _LibroRepo = libroRepo;
        }


        public async Task<bool> Insertar(Libro modelo)
        {
            try
            {
                return await _LibroRepo.Insertar(modelo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Actualizar(int id, Libro modelo)
        {
            try
            {
                return await _LibroRepo.Actualizar(id, modelo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                return await  _LibroRepo.Eliminar(id);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Libro> Obtener(int id)
        {
            try
            {
                return await _LibroRepo.Obtener(id);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Libro> Obtenerxnombre(string nombre)
        {
            try
            {
                IQueryable<Libro> queryLibros = await _LibroRepo.ObtenerTodos();
                Libro libros = queryLibros.Where(m => m.Nombre == nombre).FirstOrDefault();
                return libros;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IQueryable<Libro>> ObtenerTodos()
        {
            try
            {
                return await _LibroRepo.ObtenerTodos();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Libro>> ObtenerxAutor(int AutorID)
        {
            var query = await _LibroRepo.ObtenerTodos();

            var lista = await query.Include(m => m.Autor).Include(p => p.Editorial).Include(t => t.Categoria).Where(p=> p.AutorID== AutorID).ToListAsync();

            return lista;
        }

        public async Task<IEnumerable<Libro>> ObtenerxCategoria(int CetegoriaID)
        {
            var query = await _LibroRepo.ObtenerTodos();

            var lista = await query.Include(m => m.Categoria).Include(p => p.Editorial).Include(t => t.Categoria).Where(p => p.CategoriaID == CetegoriaID).ToListAsync();

            return lista;
        }
    }
}

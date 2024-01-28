using Digitalizar.Libros.DAL.DbContext;
using Digitalizar.Libros.DAL.Execptions;
using Digitalizar.Libros.DAL.Repository.Contrato;
using Digitalizar.Libros.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.DAL.Repository.Implementacion
{
    public class LibroRepository: IGenericRepository<Libro>
    {
        private readonly DigitalizarDbContext _dbContext;

        public LibroRepository(DigitalizarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Insertar(Libro modelo)
        {
            try 
            {
                var libros = _dbContext.Libros.Add(modelo);

                if (libros == null) throw new NotFoundException();

                
                await _dbContext.SaveChangesAsync();

                return true;

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
                var datos = await _dbContext.Libros.Where(e => e.ID == id).FirstOrDefaultAsync();
                

                if (datos == null) throw new NotFoundException();

                datos.Nombre = modelo.Nombre;

                datos.CategoriaID = modelo.CategoriaID;

                datos.AutorID = modelo.AutorID;

                datos.EditorialID  = modelo.EditorialID;

                datos.ruta = modelo.ruta;

                datos.nombre_archivo = modelo.nombre_archivo;

                _dbContext.Libros.Update(datos);

                await _dbContext.SaveChangesAsync();

                return true;

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
                Libro modelo = _dbContext.Libros.First(c => c.ID == id);

                if (modelo == null) throw new NotFoundException();

                _dbContext.Libros.Remove(modelo);

                await _dbContext.SaveChangesAsync();

                return true;
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
                var libro = await _dbContext.Libros.Where(c => c.ID == id).FirstOrDefaultAsync();

                if (libro == null) throw new NotFoundException();

                return libro;
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
                IQueryable<Libro> queryLibro = _dbContext.Libros;
                return queryLibro;
            }
            catch (Exception)
            {
                throw;
            }
        }

       
    }
}

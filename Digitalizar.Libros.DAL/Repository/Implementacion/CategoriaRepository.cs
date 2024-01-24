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
    public class CategoriaRepository :IGenericRepository<Categoria>
    {
        private readonly DigitalizarDbContext _dbContext;

        public CategoriaRepository(DigitalizarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Insertar(Categoria modelo)
        {
            try
            {
                
                var categorias =  _dbContext.Categorias.Add(modelo);
                
                if(categorias == null) throw new NotFoundException();
                
                modelo.Activar = true;
                
                await _dbContext.SaveChangesAsync();
                
                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Actualizar(int id, Categoria modelo)
        {
            try
            {
                var datos = await _dbContext.Categorias.Where(e => e.ID == id).FirstOrDefaultAsync();

                if (datos == null) throw new NotFoundException();

                datos.Name = modelo.Name;

                datos.Activar = modelo.Activar;

                _dbContext.Update(datos);
                
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
                Categoria modelo = _dbContext.Categorias.First(c => c.ID == id);

                if (modelo == null) throw new NotFoundException();

                _dbContext.Categorias.Remove(modelo);

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Categoria> Obtener(int id)
        {
            try
            {
                var categoria = await _dbContext.Categorias.Where(c => c.ID == id).FirstOrDefaultAsync();

                if (categoria == null) throw new NotFoundException();

                return categoria;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IQueryable<Categoria>> ObtenerTodos()
        {
            try
            {
                IQueryable<Categoria> queryCategorias = _dbContext.Categorias;
                return queryCategorias;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

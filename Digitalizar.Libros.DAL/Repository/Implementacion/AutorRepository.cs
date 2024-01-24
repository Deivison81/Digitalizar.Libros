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
    public class AutorRepository: IGenericRepository<Autor>
    {
        private readonly DigitalizarDbContext _dbContext;

        public AutorRepository(DigitalizarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Insertar(Autor modelo)
        {
            try 
            { 
               _dbContext.Autores.Add(modelo);
                await _dbContext.SaveChangesAsync();
                return true;

            }catch (Exception) 
            {
                throw;
            }
        }

        public async Task<bool> Actualizar(int id, Autor modelo)
        {
            try
            {
                var datos = await _dbContext.Autores.Where(e => e.ID == id).FirstOrDefaultAsync();

                if (datos == null) throw new NotFoundException();

                datos.Nombres = modelo.Nombres;

                datos.apellidos = modelo.apellidos;

                datos.Pais = modelo.Pais;

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
                Autor modelo = _dbContext.Autores.First(c => c.ID == id);

                if (modelo == null) throw new NotFoundException();

                _dbContext.Autores.Remove(modelo);

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception) 
            {
                throw;
            }

        }


        public async Task<Autor> Obtener(int id)
        {
            try 
            {
                var autores = await _dbContext.Autores.Where(c => c.ID == id).FirstOrDefaultAsync();

                if (autores == null) throw new NotFoundException();

                return autores;
            } catch (Exception) 
            {
                throw;
            }
        }

        public async Task<IQueryable<Autor>> ObtenerTodos()
        {
            try
            {
                IQueryable<Autor> queryAutores = _dbContext.Autores;
                return queryAutores;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

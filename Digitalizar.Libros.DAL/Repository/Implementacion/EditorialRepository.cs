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
    public class EditorialRepository : IGenericRepository<Editorial>
    {
        private readonly DigitalizarDbContext _dbContext;

        public EditorialRepository(DigitalizarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Insertar(Editorial modelo)
        {
            try
            {
                _dbContext.Editoriales.Add(modelo);
                await _dbContext.SaveChangesAsync();
                return true;

            }catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Actualizar(Editorial modelo)
        {
            try
            {
                var datos =  await _dbContext.Editoriales.Where(e => e.ID == modelo.ID).FirstOrDefaultAsync();
                
                if (datos == null) throw new NotFoundException();

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
                Editorial modelo = _dbContext.Editoriales.First(c => c.ID == id);

                if (modelo == null) throw new NotFoundException();

                _dbContext.Editoriales.Remove(modelo);

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        public async Task<Editorial> Obtener(int id)
        {
            try
            {
                var Editorial = await _dbContext.Editoriales.Where(c => c.ID == id).FirstOrDefaultAsync();

                if (Editorial == null) throw new NotFoundException();

                return Editorial;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IQueryable<Editorial>> ObtenerTodos()
        {
            try
            {
                IQueryable<Editorial> queryEditoriales = _dbContext.Editoriales;
                return queryEditoriales;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

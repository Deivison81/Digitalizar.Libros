using Digitalizar.Libros.BLL.Contrato;
using Digitalizar.Libros.DAL.Repository.Contrato;
using Digitalizar.Libros.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.BLL.Services
{
    public class EditorialService: IEditorialService
    {
        private readonly IGenericRepository<Editorial> _EditorialRepo;

        public EditorialService(IGenericRepository<Editorial> editorialRepo)
        {
            _EditorialRepo = editorialRepo;
        }

        public async Task<bool> Insertar(Editorial modelo)
        {
            try
            {
                return await _EditorialRepo.Insertar(modelo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Actualizar(Editorial modelo)
        {
            try
            {
                return await _EditorialRepo.Actualizar(modelo);

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
                return await _EditorialRepo.Eliminar(id);

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
                return await _EditorialRepo.Obtener(id);

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
                return await _EditorialRepo.ObtenerTodos();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Editorial> Obtenerxnombre(string nombre)
        {
            try
            {
                IQueryable<Editorial> queryEditorial = await _EditorialRepo.ObtenerTodos();
                Editorial editorial = queryEditorial.Where(m => m.Name == nombre).FirstOrDefault();
                return editorial;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

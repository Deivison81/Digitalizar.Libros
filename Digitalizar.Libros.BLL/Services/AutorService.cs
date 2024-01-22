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
    public class AutorService: IAutorService
    {
        private readonly IGenericRepository<Autor> _Autorepo;

        public AutorService(IGenericRepository<Autor> autorepo)
        {
            _Autorepo = autorepo;
        }

        public async Task<bool> Insertar(Autor modelo)
        {
            try
            {
                return await _Autorepo.Insertar(modelo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Actualizar(Autor modelo)
        {
            try
            {
                return await _Autorepo.Actualizar(modelo);

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
                return await _Autorepo.Eliminar(id);

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
                return await _Autorepo.Obtener(id);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IQueryable<Autor>> ObtenerTodos()
        {
            try
            {
                return await _Autorepo.ObtenerTodos();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Autor> Obtenerxnombre(string nombre)
        {
            try
            {
                IQueryable<Autor> queryAutor = await _Autorepo.ObtenerTodos();
                Autor Autor = queryAutor.Where(m => m.Nombres == nombre).FirstOrDefault();
                return Autor;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

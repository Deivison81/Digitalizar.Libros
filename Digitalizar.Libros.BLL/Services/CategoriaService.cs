using Digitalizar.Libros.BLL.Contrato;
using Digitalizar.Libros.DAL.Repository.Contrato;
using Digitalizar.Libros.Models.Entidades;
using Digitalizar.Libros.Models.VModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.BLL.Services
{
    public class CategoriaService: ICategoriaService
    {
        private readonly IGenericRepository<Categoria> _CategoriaRepo;

        public CategoriaService(IGenericRepository<Categoria> categoriaRepo)
        {
            _CategoriaRepo = categoriaRepo;
        }

        public async Task<bool> Insertar(Categoria modelo)
        {
            try 
            { 
               return await _CategoriaRepo.Insertar(modelo);
            }catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Actualizar(int id, Categoria modelo)
        {
            try 
            { 
                return await _CategoriaRepo.Actualizar(id, modelo);

            }catch (Exception) 
            { 
                throw; 
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try 
            { 
                return await _CategoriaRepo.Eliminar(id);

            }catch (Exception) 
            {
                throw;
            }
        }

        public async Task<Categoria> Obtener(int id)
        {
            try 
            { 
                return await _CategoriaRepo.Obtener(id);

            }catch (Exception) 
            { 
                throw; 
            }
        }

        public async Task<IQueryable<Categoria>> ObtenerTodos()
        {
            try
            {
                return await _CategoriaRepo.ObtenerTodos();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Categoria> Obtenerxnombre(string nombre)
        {
            try
            {
                IQueryable<Categoria> queryCategorias = await _CategoriaRepo.ObtenerTodos();
                Categoria categoria = queryCategorias.Where(m=> m.Name== nombre).FirstOrDefault();
                return categoria;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

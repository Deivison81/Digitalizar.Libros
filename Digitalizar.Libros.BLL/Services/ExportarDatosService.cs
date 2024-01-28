using Digitalizar.Libros.BLL.Contrato;
using Digitalizar.Libros.DAL.Repository.Contrato;
using Digitalizar.Libros.Models.Entidades;
using Digitalizar.Libros.Models.VModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Digitalizar.Libros.BLL.Services
{
    public class ExportarDatosService : IExportarDatos
    {
        private readonly IGenericRepository<Autor> _AutorRepo;

        private readonly IGenericRepository<Categoria> _CategoriaRepo;

        private readonly IGenericRepository<Libro> _LibrosRepo;

        private readonly ILibroService _LibroService;

        public ExportarDatosService(IGenericRepository<Autor> autorRepo, IGenericRepository<Categoria> categoriaRepo, IGenericRepository<Libro> librosRepo, ILibroService libroService)
        {
            _AutorRepo = autorRepo;
            _CategoriaRepo = categoriaRepo;
            _LibrosRepo = librosRepo;
            _LibroService = libroService;
        }

        public async Task<VMExportar> ExportarTotales()
        {
            try
            {
                IQueryable<Autor> queryautores = await _AutorRepo.ObtenerTodos();
                int Autores = (queryautores).Count();

                IQueryable<Categoria> queryCategorias = await _CategoriaRepo.ObtenerTodos();
                int categoria = (queryCategorias).Count();

                IQueryable<Libro> querylibros = await _LibrosRepo.ObtenerTodos();
                int Libros = (querylibros).Count();



                 var categoriaT =  await _LibroService.ObtenerTodos();
                var total = categoriaT.GroupBy(p => p.CategoriaID);
                int librosxcategoria = total.Count(); 
                
                VMExportar totales = new VMExportar() 
                { 
                    Total_Autores = Autores,

                    Total_Categorias = categoria,

                    Total_Libros = Libros, 
                    
                    Total_librosxCategoria = librosxcategoria,
                };

               



                return totales;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

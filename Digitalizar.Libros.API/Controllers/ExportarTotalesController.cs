using ClosedXML.Excel;
using Digitalizar.Libros.API.Migrations;
using Digitalizar.Libros.BLL.Contrato;
using Digitalizar.Libros.DAL.Execptions;
using Digitalizar.Libros.Models.VModels;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Digitalizar.Libros.API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExportarTotalesController : ControllerBase
    {
        private readonly IExportarDatos _exportarDatosService;

        public ExportarTotalesController(IExportarDatos exportarDatosService)
        {
            _exportarDatosService = exportarDatosService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult> ExportarDatos()
        {


            var totales = await _exportarDatosService.ExportarTotales();

            DataTable tabla = new DataTable();

            DataColumn columna = new DataColumn();

            DataRow fila;
            

            columna.DataType = typeof(int);
            columna.ColumnName = "reng";
            tabla.Columns.Add("reng");

            columna.DataType = typeof(int);
            columna.ColumnName = "Total libros";
            tabla.Columns.Add("Total_libros");
            
            columna.DataType = typeof(int);
            columna.ColumnName = "Total Autores";
            tabla.Columns.Add(new DataColumn("Total_Autores"));

            columna.DataType = typeof(int);
            columna.ColumnName = "Total Categorias";
            tabla.Columns.Add(new DataColumn("Total_Categorias"));

            columna.DataType = typeof(int);
            columna.ColumnName = "Total libros Categoria";
            tabla.Columns.Add(new DataColumn("Total_libros_Categoria"));

            

            for (int i = 1; i < 2; i++)
            {
                var Fila = tabla.NewRow();

                Fila["reng"] = i;

                Fila["Total_libros"] = totales.Total_Libros;

                Fila["Total_Autores"] = totales.Total_Autores;

                Fila["Total_Categorias"] = totales.Total_Categorias;

                Fila["Total_libros_Categoria"] = totales.Total_librosxCategoria;

                tabla.Rows.Add( Fila );

            }

            using (var Libro = new XLWorkbook()) 
            {
                tabla.TableName = "Totales";
                var hojas = Libro.Worksheets.Add(tabla);
                hojas.ColumnsUsed().AdjustToContents();

                using (var memoria = new MemoryStream()) 
                {
                    Libro.SaveAs(memoria);

                    var Totalesexcel = string.Concat("Reportes Totales", DateTime.Now.ToString(), ".xlsx");

                    return File(memoria.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheel", Totalesexcel);

                };

            }

                
                
        }

    }
}

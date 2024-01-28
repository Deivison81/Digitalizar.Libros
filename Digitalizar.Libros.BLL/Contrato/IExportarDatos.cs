using Digitalizar.Libros.Models.Entidades;
using Digitalizar.Libros.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.BLL.Contrato
{
    public interface IExportarDatos
    {
        Task<VMExportar> ExportarTotales();
    }
}

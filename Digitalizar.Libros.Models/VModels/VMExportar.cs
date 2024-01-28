using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.Models.VModels
{
    public class VMExportar
    {
        public int Total_Libros { get; set; }

        public int Total_Autores { get; set; }

        public int Total_Categorias {  get; set; }
        
        public int Total_librosxCategoria { get; set; }

        public VMExportar Totales { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.Models.VModels
{
    public class VMEmail
    {
        public string Para { get; set; } = string.Empty;
        
        public string Asunto { get; set; } = string.Empty;
        
        public string Contenido { get; set; } = string.Empty;
    }
}

using Digitalizar.Libros.Models.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.Models.VModels
{
    public class VMLibro
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public int CategoriaID { get; set; }
        
        public int EditorialID { get; set; }

        public int AutorID { get; set; }

        [MaxLength(60)]
        public string ruta { get; set; }
        [MaxLength(45)]
        public string nombre_archivo { get; set; }
    }
}

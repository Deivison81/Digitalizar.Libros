using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.Models.Entidades
{
    public class Categoria
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public bool Activar { get; set; }
    }
}

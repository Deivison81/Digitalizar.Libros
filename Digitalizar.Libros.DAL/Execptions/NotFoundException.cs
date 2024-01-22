using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.DAL.Execptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException( string ? menssage = "No existe un registro con el ID especificado."): base(menssage) 
        { 
        
        }
    }
}

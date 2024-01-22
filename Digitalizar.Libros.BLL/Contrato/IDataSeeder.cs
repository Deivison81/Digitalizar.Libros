using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.BLL.Contrato
{
    public interface IDataSeeder
    {
        public Task CrearUsuarioAdmin();

        public Task CrearRoles();
    }
}

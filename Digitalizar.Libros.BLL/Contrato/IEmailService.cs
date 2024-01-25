using Digitalizar.Libros.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.BLL.Contrato
{
    public interface IEmailService
    {
        Task<bool> EnviarEmailAsync(string emailDestinatario, string asunto, string mensaje);

        void SendEmail(VMEmail request);
    }
}

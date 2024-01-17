using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Digitalizar.Libros.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.DAL.DbContext
{
    public class DigitalizarDbContext : IdentityDbContext<Usuario>
    {
        public DigitalizarDbContext(DbContextOptions options): base(options) 
        { 
        
        }
        
            
        
    }
}

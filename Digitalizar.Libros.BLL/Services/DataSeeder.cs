using Digitalizar.Libros.BLL.Contrato;
using Digitalizar.Libros.Models.Entidades;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.BLL.Services
{
    public class DataSeeder : IDataSeeder
    {
        private readonly UserManager<Usuario> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DataSeeder(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task CrearRoles()
        {
            string[] roles = { "Admin", "Usuario" };

            foreach (string rol in roles)
            {
                try 
                { 
                    var existeRol = await roleManager.RoleExistsAsync(roleName: rol);

                    if (!existeRol) await roleManager.CreateAsync(new IdentityRole(roleName: rol));
                

                }
                catch (Exception) 
                {
                    throw;
                }
            }
        }

        public async Task CrearUsuarioAdmin()
        {
            try 
            {
                string email = "admin@gmail.com";
                
                var admin = await userManager.FindByEmailAsync(email);
                
                if (admin != null) return;
                
                var nuevoAdmin = new Usuario { UserName = email, Email = email };

                var resultado = await userManager.CreateAsync(nuevoAdmin, "Admin1234!");

                if (!resultado.Succeeded) throw new Exception("no se pudo Crear el usuario Administrador");

                var resultadoRol = await userManager.AddToRoleAsync(nuevoAdmin, "Admin");

            }catch (Exception) 
            {
                throw;
            }
        }
    }
}

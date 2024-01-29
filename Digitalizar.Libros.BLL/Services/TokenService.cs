using Digitalizar.Libros.BLL.Contrato;
using Digitalizar.Libros.Models.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.BLL.Services
{
    public class TokenService: ITokenService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IConfiguration _configuration;

        public TokenService(UserManager<Usuario> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> GenerarToken(string email, int diasExpiracion)
        {
           var usuario = await _userManager.FindByEmailAsync(email);

            var roles = await _userManager.GetRolesAsync(usuario);

            var claims = new List<Claim>() { new Claim("mail", email), new Claim("id", usuario.Id) };

            foreach (var role in roles) 
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["llaveJwt"]!));

            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddDays(diasExpiracion);

            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiracion, signingCredentials: creds);

            var respuestaTocken = new JwtSecurityTokenHandler().WriteToken(token);

            return respuestaTocken;    

        }
        
        
        
    }
}

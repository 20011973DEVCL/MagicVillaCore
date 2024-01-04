
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MagicVilla.Data;
using MagicVilla.Models.Custom;
using Microsoft.IdentityModel.Tokens;

namespace MagicVilla.Services
{
    public class AutorizacionService : IAutorizacionService
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;

        public AutorizacionService(ApplicationDbContext db, IConfiguration configuration)
        {
           this._configuration=configuration;
           this._db=db; 
        }

        private string GenerarToken(string IdUsuario)
        {
            var key= _configuration.GetValue<string>("JwtSettings:Key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier,IdUsuario));

            var credencialesToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = credencialesToken
            };

            var tokenHandler= new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);

            return tokenCreado;

        }
        public async Task<AutorizacionResponse> DevolverToken(AutorizacionRequest autorizacion)
        {
            var usuario_encontrado = _db.Usuarios.FirstOrDefault(
                x=> x.NombreUsuario == autorizacion.NombreUsuario &&
                x.Clave == autorizacion.Clave
            );

            if (usuario_encontrado==null)
            {
                return await Task.FromResult<AutorizacionResponse>(null);
            }

            var tokenCreado= GenerarToken(usuario_encontrado.IdUsuario.ToString());

            return new AutorizacionResponse() {Token = tokenCreado, Resultado = true, Msg="Ok"};
        }
    }
}
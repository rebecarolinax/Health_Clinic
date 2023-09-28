using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.healthclinic.codefirst.Domains;
using webapi.healthclinic.codefirst.Interfaces;
using webapi.healthclinic.codefirst.Repositories;
using webapi.healthclinic.codefirst.ViewModels;

namespace webapi.healthclinic.codefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "E-mail ou senha inválidos!");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario!.Titulo!)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("healthc-webapi-chave-autenticacao-ef"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //token
                var meuToken = new JwtSecurityToken(
                        issuer: "webapi.healthclinic.codefirst",
                        audience: "webapi.healthclinic.codefirst",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(15),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}

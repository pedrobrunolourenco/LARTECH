using Lartech.Api.Setup.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Lartech.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration configuration)
        {
            _config = configuration;    
        }

        private Users AutenticacaoUsuario(Users user)
        {
            Users _user = null;
            if(user.Login == "Adm" && user.Senha == "12345")
            {
                _user = new Users { Login = "LARTech" };
            }
            return _user;
        }

        private string GerarToken(Users users)
        {
            var chaveSegura = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("App-Teste-Pedro-Bruno"));
            var credencial = new SigningCredentials(chaveSegura, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(null,
                                             expires: DateTime.Now.AddMinutes(90),
                                             signingCredentials: credencial
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //private string GerarJwt()
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes("App-Teste-Pedro-Bruno");
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Expires = DateTime.UtcNow.AddHours(5),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        //}


        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Logar(Users login)
        {
            IActionResult response = Unauthorized();
            var user_ = AutenticacaoUsuario(login);
            if (user_ != null)
            {
                // var token = GerarToken(user_);
                var token = GerarToken(login);
                response = Ok(new { Token = token });
            }

            return response;

        }

    }
}

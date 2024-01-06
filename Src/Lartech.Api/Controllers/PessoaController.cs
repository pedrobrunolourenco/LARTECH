
using Lartech.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lartech.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private IAppPessoa _appPessoa;

        public PessoaController(IAppPessoa appPessoa)
        {
            _appPessoa = appPessoa;
        }


        [HttpGet]
        [Route("Obter-Todas")]
        [AllowAnonymous]
        public async Task<IActionResult> ObterTodas()
        {
            var result = _appPessoa.ObterTodas();
            return Ok(new
            {
                Sucesso = true,
                Data = result
            });
        }

    }
}

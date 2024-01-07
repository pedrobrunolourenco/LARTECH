
using Lartech.Application.Interfaces;
using Lartech.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lartech.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController :  BasicaController
    {
        private IAppPessoa _appPessoa;
        private ILogger _logger;


        public PessoaController(IAppPessoa appPessoa,
                                ILogger<PessoaController> logger)
        {
            _appPessoa = appPessoa;
            _logger = logger;
        }


        [HttpGet]
        [Route("ObterTodos")]
        [AllowAnonymous]
        public IActionResult ObterTodos()
        {
            try
            {
                var result = _appPessoa.ObterTodos();
                return RetornoRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ObterTodos {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("ObterPorId")]
        [AllowAnonymous]
        public IActionResult ObterPorId(Guid id)
        {
            try
            {
                var result = _appPessoa.ObterPorId(id);
                return RetornoRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ObterPorId {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("ObterPorCPF")]
        [AllowAnonymous]
        public IActionResult ObterPorCpf(string cpf)
        {
            try
            {
                var result = _appPessoa.ObterPorCpf(cpf);
                return RetornoRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ObterPorCPF {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("ObterPorParteNome")]
        [AllowAnonymous]
        public IActionResult ObterPorParteDoNome(string nome)
        {
            try
            {
                var result = _appPessoa.ObterPorParteDoNome(nome);
                return RetornoRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ObterPorParteNome {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("ObterAtivos")]
        [AllowAnonymous]
        public IActionResult ObterAtivos()
        {
            try
            {
                var result = _appPessoa.ObterAtivos();
                return RetornoRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ObterAtivos {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("ObterInativos")]
        [AllowAnonymous]
        public IActionResult ObterInativos()
        {
            try
            {
                var result = _appPessoa.ObterInativos();
                return RetornoRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ObterInativos {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("IncluirPessoa")]
        [AllowAnonymous]
        public IActionResult IncluirPessoa([FromBody] PessoaModel model)
        {
            try
            {
                var pessoa = _appPessoa.IncluirPessoa(model);
                return RetornoRequest(pessoa,pessoa.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"IncluirPessoa {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("AlterarPessoa")]
        [AllowAnonymous]
        public IActionResult AlterarPessoa([FromBody] PessoaAlteracaoModel model)
        {
            try
            {
                var pessoa = _appPessoa.AlterarPessoa(model);
                return RetornoRequest(pessoa, pessoa.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AlterarPessoa {ex.Message}");
                return BadRequest();
            }
        }


    }
}

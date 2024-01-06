
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
        [Route("Obter-Todos")]
        [AllowAnonymous]
        public IActionResult ObterTodas()
        {
            try
            {
                var result = _appPessoa.ObterTodos();
                return RetornoRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Obter-Todas {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Obter-Por-Id")]
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
                _logger.LogError($"Obter-Por-Id {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Obter-Por-CPF")]
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
                _logger.LogError($"Obter-Por-CPF {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Obter-Por-Parte-Do-Nome")]
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
                _logger.LogError($"Obter-Por-Parte-Do-Nome {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Obter-Ativos")]
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
                _logger.LogError($"Obter-Ativos {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Obter-Inativos")]
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
                _logger.LogError($"Obter-Inativos {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Incluir-Pessoa")]
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
                _logger.LogError($"Incluir-Pessoa {ex.Message}");
                return BadRequest();
            }
        }

    }
}

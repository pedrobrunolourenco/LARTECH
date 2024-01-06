
using Lartech.Application.Interfaces;
using Lartech.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lartech.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
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
        [Route("Obter-Todas")]
        [AllowAnonymous]
        public IActionResult ObterTodas()
        {
            try
            {
                var result = _appPessoa.ObterTodas();
                return Ok(new
                {
                    Sucesso = true,
                    Data = result
                });
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
                return Ok(new
                {
                    Sucesso = true,
                    Data = result
                });
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
                return Ok(new
                {
                    Sucesso = true,
                    Data = result
                });
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
                return Ok(new
                {
                    Sucesso = true,
                    Data = result
                });
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

                return Ok(new
                {
                    Sucesso = true,
                    Data = result
                });
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
                return Ok(new
                {
                    Sucesso = true,
                    Data = result
                });
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
                if(pessoa.ListaErros.Any())
                {
                    var erros = AddErros(pessoa.ListaErros);
                    return BadRequest(new
                    {
                        Sucesso = false,
                        Data = pessoa,
                        Mensagens = erros
                    });
                }
                return Ok(new
                {
                    Sucesso = !pessoa.ListaErros.Any(),
                    Data = pessoa
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Incluir-Pessoa {ex.Message}");
                return BadRequest();
            }
        }

        private List<string> AddErros(List<string> erros)
        {
            var _errors = new List<string>();
            foreach (var item in erros)
            {
                _errors.Add(item);
            }
            return _errors;
        }
    }
}

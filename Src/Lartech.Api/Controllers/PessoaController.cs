
using Lartech.Application.Interfaces;
using Lartech.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lartech.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpDelete]
        [Route("RemoverPessoa")]
        public IActionResult RemoverPessoa(Guid id)
        {
            try
            {
                var pessoa = _appPessoa.ExcluirPessoa(id);
                return RetornoRequest(pessoa, pessoa.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"RemoverPessoa {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("IncluirTelefone")]
        public IActionResult IncluirTelefone([FromBody] TelefoneModel model, Guid idpessoa)
        {
            try
            {
                var telefone = _appPessoa.AdicionarTelefone(model,idpessoa);
                return RetornoRequest(telefone, telefone.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"IncluirTelefone {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("AlterarTelefone")]
        public IActionResult AlterarTelefone([FromBody] TelefoneAlteracaoModel model)
        {
            try
            {
                var telefone = _appPessoa.AlterarTelefone(model);
                return RetornoRequest(telefone, telefone.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AlterarTelefone {ex.Message}");
                return BadRequest();
            }
        }


        [HttpDelete]
        [Route("RemoverTelefone")]
        public IActionResult RemoverTelefone(Guid id)
        {
            try
            {
                var telefone = _appPessoa.ExcluirTelefone(id);
                return RetornoRequest(telefone, telefone.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"RemoverTelefone {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("AtivarPessoa")]
        public IActionResult AtivarPessoa(Guid id)
        {
            try
            {
                var pessoa = _appPessoa.Ativar(id);
                return RetornoRequest(pessoa, pessoa.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AtivarPessoa {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("InativarPessoa")]
        public IActionResult InativarPessoa(Guid id)
        {
            try
            {
                var pessoa = _appPessoa.Inativar(id);
                return RetornoRequest(pessoa, pessoa.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"InativarPessoa {ex.Message}");
                return BadRequest();
            }
        }

    }
}

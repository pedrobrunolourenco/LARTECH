using Lartech.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lartech.Api.Controllers
{
    public abstract class  BasicaController : ControllerBase
    {
        protected IActionResult RetornoRequest(object? result)
        {
            return Ok(new
            {
                Sucesso = true,
                Data = result
            });
        }



        protected IActionResult RetornoRequest(object? result, List<string> erros)
        {
            if (erros.Any())
            {
                return BadRequest(new
                {
                    Sucesso = false,
                    Data = result,
                    Mensagens = erros
                });
            }
            else
            {
                return RetornoRequest(result);
            }
        }

        protected List<string> AddErros(List<string> erros)
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

using Lartech.Domain.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Lartech.Application.Models
{
    public class TelefoneModel
    {
        public TelefoneModel()
        {
            Id = Guid.NewGuid();
            ListaErros = new List<string>();
        }

        [Key]
        [IgnoreDataMember]
        public Guid Id { get; set; }

        [IgnoreDataMember]
        public List<string> ListaErros { get; set; }

        public Guid PessoaId { get; private set; }
        public TipoTelefone Tipo { get; private set; }

        [Required(ErrorMessage = "Necessário informar número")]
        [MinLength(5, ErrorMessage = "Número deve ter no mínimo 11 caracteres")]
        [MaxLength(11, ErrorMessage = "Número deve ter no mínimo 11 caracteres")]
        public string Numero { get; private set; }


    }
}

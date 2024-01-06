using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Lartech.Application.Models
{
    public class PessoaModel
    {
        public PessoaModel()
        {
            Id = Guid.NewGuid();
            ListaErros = new List<string>();
        }

        [Key]
        [IgnoreDataMember]
        public Guid Id { get; set; }

        [IgnoreDataMember]
        public List<string> ListaErros { get; set; }

        [Required(ErrorMessage = "Necessário informar nome")]
        [MinLength(5,ErrorMessage = "Nome deve ter no mínimo 5 caractestes")]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caractestes")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Necessário informar CPF")]
        [MinLength(11, ErrorMessage = "CPF deve ter 11 caracteres")]
        [MaxLength(11, ErrorMessage = "CPF deve ter 11 caracteres")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Necessário informar Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [IgnoreDataMember]
        public bool Ativo { get; set; } = true;



    }
}

using Lartech.Domain.Entidades;

namespace Lartech.Domain.DTOS
{
    public class PessoaDTO
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public TipoTelefone Tipo { get; set; }
        public string? Numero { get; set; }
    }
}

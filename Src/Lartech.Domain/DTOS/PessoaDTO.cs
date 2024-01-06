using Lartech.Domain.Entidades;

namespace Lartech.Domain.DTOS
{
    public class PessoaDTO
    {
        public PessoaDTO()
        {
           Telefones = new List<Telefone>();
        }
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public List<Telefone> Telefones { get; set; }
    }
}

using Lartech.Domain.DTOS;
using Lartech.Domain.Entidades;

namespace Lartech.Domain.Interfaces.Repository
{
    public interface IRepositoryPessoa : IRepository<Pessoa>
    {
        IEnumerable<PessoaViewModel> ObterPorParteDoNome(string nome);
        IEnumerable<Pessoa> ObterAtivos();
        IEnumerable<Pessoa> ObterInativos();
        Pessoa? ObterPorCpf(string cpf);
        Pessoa Inativar(Pessoa pessoa);
        Pessoa Ativar(Pessoa pessoa);
    }
}

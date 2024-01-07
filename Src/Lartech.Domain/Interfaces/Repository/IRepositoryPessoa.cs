using Lartech.Domain.DTOS;
using Lartech.Domain.Entidades;

namespace Lartech.Domain.Interfaces.Repository
{
    public interface IRepositoryPessoa : IRepository<Pessoa>
    {
        PessoaViewModel? ObterPorId(Guid id);
        IEnumerable<PessoaViewModel> ObterTodos();
        IEnumerable<PessoaViewModel> ObterPorParteDoNome(string nome);
        IEnumerable<PessoaViewModel> ObterAtivos();
        IEnumerable<PessoaViewModel> ObterInativos();

        PessoaViewModel? ObterPorCpf(string cpf);
        Pessoa Inativar(Pessoa pessoa);
        Pessoa Ativar(Pessoa pessoa);

    }
}

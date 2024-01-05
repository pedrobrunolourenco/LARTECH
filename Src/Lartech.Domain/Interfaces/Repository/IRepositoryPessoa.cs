using Lartech.Domain.Entidades;

namespace Lartech.Domain.Interfaces.Repository
{
    public interface IRepositoryPessoa : IRepository<Pessoa>
    {
        Pessoa? ObterPorNome(string nome);
        Pessoa? ObterPorCpf(string cpf);
        Pessoa Inativar(Pessoa pessoa);
        Pessoa Ativar(Pessoa pessoa);
    }
}

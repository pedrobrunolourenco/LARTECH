using Lartech.Domain.Entidades;

namespace Lartech.Domain.Interfaces.Service
{
    public interface IServicePessoa
    {
        IEnumerable<Pessoa> ObterTodas();
        Pessoa? ObterPorId(Guid id);
        Pessoa? ObterPorCpf(string cpf);
        Pessoa? ObterPorNome(string nome);
        Pessoa Ativar(Pessoa pessoa);
        Pessoa Inativar(Pessoa pessoa);

        Pessoa IncluirPessoa(Pessoa pessoa);
        Pessoa AlterarPessoa(Pessoa pessoa);
        void ExcluirPessoa(Guid id);
    }
}

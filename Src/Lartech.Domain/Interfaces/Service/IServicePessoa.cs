using Lartech.Domain.DTOS;
using Lartech.Domain.Entidades;

namespace Lartech.Domain.Interfaces.Service
{
    public interface IServicePessoa
    {
        IEnumerable<Pessoa> ObterTodas();
        Pessoa? ObterPorId(Guid id);
        Pessoa? ObterPorCpf(string cpf);
        IEnumerable<PessoaViewModel> ObterPorParteDoNome(string nome);

        IEnumerable<Pessoa> ObterAtivos();
        IEnumerable<Pessoa> ObterInativos();

        Pessoa IncluirPessoa(Pessoa pessoa);
        Pessoa AlterarPessoa(Pessoa pessoa);
        void ExcluirPessoa(Guid id);

        Telefone AdicionarTelefone(Telefone fone);
        Telefone AlterarTelefone(Telefone fone);
        void ExcluirTelefone(Guid idtelefone);

        Pessoa Ativar(Pessoa pessoa);
        Pessoa Inativar(Pessoa pessoa);

    }
}

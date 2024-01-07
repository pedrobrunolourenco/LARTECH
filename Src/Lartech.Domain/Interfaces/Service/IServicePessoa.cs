using Lartech.Domain.DTOS;
using Lartech.Domain.Entidades;

namespace Lartech.Domain.Interfaces.Service
{
    public interface IServicePessoa
    {
        IEnumerable<PessoaViewModel> ObterTodos();
        PessoaViewModel? ObterPorId(Guid id);
        PessoaViewModel? ObterPorCpf(string cpf);
        IEnumerable<PessoaViewModel> ObterPorParteDoNome(string nome);

        IEnumerable<PessoaViewModel> ObterAtivos();
        IEnumerable<PessoaViewModel> ObterInativos();

        Pessoa IncluirPessoa(Pessoa pessoa);
        Pessoa AlterarPessoa(Pessoa pessoa);
        void ExcluirPessoa(Guid id);

        IEnumerable<Telefone> ObterTelefonesDaPessoa(Guid idpessoa);
        Telefone AdicionarTelefone(Telefone fone);
        Telefone AlterarTelefone(Telefone fone);
        void ExcluirTelefone(Guid idtelefone);

        Pessoa Ativar(Pessoa pessoa);
        Pessoa Inativar(Pessoa pessoa);

    }
}

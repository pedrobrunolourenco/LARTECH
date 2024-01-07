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
        Pessoa AlterarPessoa(Pessoa pessoa, Guid id);
        Pessoa ExcluirPessoa(Guid id);

        IEnumerable<Telefone> ObterTelefonesDaPessoa(Guid idpessoa);
        Telefone AdicionarTelefone(Telefone fone, Guid idpessoa);
        Telefone AlterarTelefone(Telefone fone);
        Telefone ExcluirTelefone(Guid idtelefone);

        Pessoa AtivarPessoa(Guid id);
        Pessoa InativarPessoa(Guid id);

    }
}

using Lartech.Application.Models;
using Lartech.Domain.DTOS;

namespace Lartech.Application.Interfaces
{
    public interface IAppPessoa
    {
        IEnumerable<PessoaViewModel> ObterTodos();
        PessoaViewModel? ObterPorId(Guid id);
        PessoaViewModel? ObterPorCpf(string cpf);
        IEnumerable<PessoaViewModel> ObterPorParteDoNome(string nome);

        IEnumerable<PessoaViewModel> ObterAtivos();
        IEnumerable<PessoaViewModel> ObterInativos();

        PessoaModel IncluirPessoa(PessoaModel pessoa);
        PessoaModel AlterarPessoa(PessoaAlteracaoModel pessoa);
        PessoaViewModel? ExcluirPessoa(Guid id);

        TelefoneModel AdicionarTelefone(TelefoneModel fone);
        TelefoneModel AlterarTelefone(TelefoneModel fone);
        void ExcluirTelefone(Guid idtelefone);

        PessoaModel Ativar(PessoaModel pessoa);
        PessoaModel Inativar(PessoaModel pessoa);

    }
}

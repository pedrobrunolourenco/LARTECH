using Lartech.Application.Models;

namespace Lartech.Application.Interfaces
{
    public interface IAppPessoa
    {
        IEnumerable<PessoaModel> ObterTodas();
        PessoaModel? ObterPorId(Guid id);
        PessoaModel? ObterPorCpf(string cpf);
        IEnumerable<PessoaModel> ObterPorParteDoNome(string nome);

        IEnumerable<PessoaModel> ObterAtivos();
        IEnumerable<PessoaModel> ObterInativos();

        PessoaModel IncluirPessoa(PessoaModel pessoa);
        PessoaModel AlterarPessoa(PessoaModel pessoa);
        void ExcluirPessoa(Guid id);

        TelefoneModel AdicionarTelefone(TelefoneModel fone);
        TelefoneModel AlterarTelefone(TelefoneModel fone);
        void ExcluirTelefone(Guid idtelefone);

        PessoaModel Ativar(PessoaModel pessoa);
        PessoaModel Inativar(PessoaModel pessoa);

    }
}

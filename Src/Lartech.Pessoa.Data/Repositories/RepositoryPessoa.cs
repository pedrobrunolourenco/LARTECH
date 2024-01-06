using Lartech.Domain.Entidades;
using Lartech.Domain.Interfaces.Repository;

namespace Lartech.Data.Repositories
{
    public class RepositoryPessoa : Repository<Pessoa>, IRepositoryPessoa
    {

        public RepositoryPessoa(DataContext context) : base(context)
        {

        }

        public Pessoa Ativar(Pessoa pessoa)
        {
            pessoa.Ativar();
            Atualizar(pessoa);
            Salvar();
            return pessoa;
        }

        public Pessoa Inativar(Pessoa pessoa)
        {
            pessoa.Inativar();
            Atualizar(pessoa);
            Salvar();
            return pessoa;
        }

        public IEnumerable<Pessoa> ObterAtivos()
        {
            return Listar().Where(p => p.Ativo.Equals(true));

        }

        public IEnumerable<Pessoa> ObterInativos()
        {
            return Listar().Where(p => p.Ativo.Equals(false));
        }

        public Pessoa? ObterPorCpf(string cpf)
        {
            return Listar().Where(p => p.CPF == cpf).FirstOrDefault();
        }

        public IEnumerable<Pessoa> ObterPorParteDoNome(string nome)
        {
            return Listar().Where(p => p.Nome.Contains(nome));
        }
    }
}

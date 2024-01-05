using Lartech.Domain.Entidades;
using Lartech.Domain.Interfaces.Repository;
using Lartech.Domain.Interfaces.Service;

namespace Lartech.Domain.Services
{
    public class ServicePessoa : IServicePessoa
    {

        private readonly IRepositoryPessoa _repositoryPessoa;

        public ServicePessoa(IRepositoryPessoa repositoryPessoa)
        {
            _repositoryPessoa = repositoryPessoa;
        }


        public Pessoa IncluirPessoa(Pessoa pessoa)
        {
            if (!pessoa.Validar()) return pessoa;
            _repositoryPessoa.Adicionar(pessoa);
            _repositoryPessoa.Salvar();
            return pessoa;
        }


        public Pessoa AlterarPessoa(Pessoa pessoa)
        {
            if (!pessoa.Validar()) return pessoa;
            _repositoryPessoa.DetachAllEntities();
            _repositoryPessoa.Atualizar(pessoa);
            _repositoryPessoa.Salvar();
            return pessoa;
        }

        public Pessoa Ativar(Pessoa pessoa)
        {
            return _repositoryPessoa.Ativar(pessoa);
        }

        public void ExcluirPessoa(Guid id)
        {
            var pessoa = _repositoryPessoa.ObterPorId(id);
            if (pessoa == null) return;
            _repositoryPessoa.DetachAllEntities();
            _repositoryPessoa.Remover(pessoa);
            _repositoryPessoa.Salvar();
        }

        public Pessoa Inativar(Pessoa pessoa)
        {
            return _repositoryPessoa.Inativar(pessoa);
        }

        public Pessoa? ObterPorCpf(string cpf)
        {
            return _repositoryPessoa.ObterPorCpf(cpf);
        }

        public Pessoa? ObterPorId(Guid id)
        {
            return _repositoryPessoa.ObterPorId(id);
        }

        public Pessoa? ObterPorNome(string nome)
        {
            return _repositoryPessoa.ObterPorNome(nome);
        }

        public IEnumerable<Pessoa> ObterTodas()
        {
            return _repositoryPessoa.Listar();
        }
    }
}

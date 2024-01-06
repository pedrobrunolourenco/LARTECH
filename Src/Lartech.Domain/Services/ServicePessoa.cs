using Lartech.Domain.DTOS;
using Lartech.Domain.Entidades;
using Lartech.Domain.Interfaces.Repository;
using Lartech.Domain.Interfaces.Service;
using static System.Net.Mime.MediaTypeNames;

namespace Lartech.Domain.Services
{
    public class ServicePessoa : IServicePessoa
    {

        private readonly IRepositoryPessoa _repositoryPessoa;
        private readonly IRepositoryTelefone _repositoryTelefone;

        public ServicePessoa(IRepositoryPessoa repositoryPessoa,
                             IRepositoryTelefone repositoryTelefone)
        {
            _repositoryPessoa = repositoryPessoa;
            _repositoryTelefone = repositoryTelefone;
        }


        public Pessoa IncluirPessoa(Pessoa pessoa)
        {
            if (!pessoa.Validar()) return pessoa;
            if(NaoAdicionouTodosOsTelefones(pessoa)) return pessoa;
            if (ValidarRegrasDeDominio(pessoa).ListaErros.Any()) return pessoa;

            pessoa.Ativar();

            _repositoryPessoa.Adicionar(pessoa);
            _repositoryPessoa.Salvar();



            return pessoa;
        }

        private bool NaoAdicionouTodosOsTelefones(Pessoa pessoa)
        {
            foreach (var telefone in pessoa.ListaTelefones)
            {
                if(telefone.Validar())
                {
                    _repositoryTelefone.Adicionar(telefone);
                }
                else
                {
                    foreach (var erroTelefone in telefone.ListaErros)
                    {
                        pessoa.ListaErros.Add(erroTelefone);
                    }
                }
            }
            return pessoa.ListaErros.Any();
        }

        private Pessoa ValidarRegrasDeDominio(Pessoa pessoa)
        {
            if (VerificarSeCPFJaExiste(pessoa))  pessoa.ListaErros.Add($"O CPF {pessoa.CPF} já existe para outra pessoa.");
            return pessoa;
        }


        public Pessoa AlterarPessoa(Pessoa pessoa)
        {
            if (!pessoa.Validar()) return pessoa;
            if (VerificarSeCPFJaExiste(pessoa))
            {
                pessoa.ListaErros.Add($"O CPF {pessoa.CPF} já existe para outra pessoa.");
                return pessoa;
            }
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
            // var pessoa = _repositoryPessoa.ObterPorId(id);
            // if (pessoa == null) return;
            // _repositoryPessoa.DetachAllEntities();
            // _repositoryPessoa.Remover(pessoa);
            // _repositoryPessoa.Salvar();
        }

        public Pessoa Inativar(Pessoa pessoa)
        {
            return _repositoryPessoa.Inativar(pessoa);
        }

        public PessoaViewModel? ObterPorCpf(string cpf)
        {
            return _repositoryPessoa.ObterPorCpf(cpf);
        }

        public PessoaViewModel? ObterPorId(Guid id)
        {
            return _repositoryPessoa.ObterPorId(id);
        }

        public IEnumerable<PessoaViewModel> ObterPorParteDoNome(string nome)
        {

            return _repositoryPessoa.ObterPorParteDoNome(nome);
        }

        public IEnumerable<PessoaViewModel> ObterTodos()
        {
            return _repositoryPessoa.ObterTodos();
        }

        public IEnumerable<PessoaViewModel> ObterAtivos()
        {
            return _repositoryPessoa.ObterAtivos();
        }

        public IEnumerable<PessoaViewModel> ObterInativos()
        {
            return _repositoryPessoa.ObterInativos();
        }


        public Telefone AdicionarTelefone(Telefone fone)
        {
            if (!fone.Validar()) return fone;
            if (VerificarSeTelefoneJaExiste(fone)) 
            { 
                fone.ListaErros.Add($"O telefone {fone.Numero} já existe para outra pessoa." );
                return fone;
            }
            _repositoryTelefone.Adicionar(fone);
            _repositoryPessoa.Salvar();
            return fone;
        }

        public Telefone AlterarTelefone(Telefone fone)
        {
            if (!fone.Validar()) return fone;
            if (VerificarSeTelefoneJaExiste(fone))
            {
                fone.ListaErros.Add($"O telefone {fone.Numero} já existe para outra pessoa.");
                return fone;
            }
            _repositoryTelefone.DetachAllEntities();
            _repositoryTelefone.Atualizar(fone);
            _repositoryTelefone.Salvar();
            return fone;
        }

        public void ExcluirTelefone(Guid idtelefone)
        {
            //var fone = _repositoryTelefone.ObterPorId(idtelefone);
            //if (fone == null) return;
            //_repositoryTelefone.DetachAllEntities();
            //_repositoryTelefone.Remover(fone);
            //_repositoryTelefone.Salvar();
        }

        private bool VerificarSeTelefoneJaExiste(Telefone telefone)
        {
            return _repositoryTelefone.Listar().Where(t => t.Numero == telefone.Numero && t.Id != telefone.Id).Any();
        }

        private bool VerificarSeCPFJaExiste(Pessoa pessoa)
        {
            return _repositoryPessoa.Listar().Where(p => p.CPF == pessoa.CPF && p.Id != pessoa.Id).Any();
        }

    }
}

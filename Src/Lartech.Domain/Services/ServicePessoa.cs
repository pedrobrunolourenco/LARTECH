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

        public Pessoa AlterarPessoa(Pessoa pessoa, Guid id)
        {
            var _pessoa = _repositoryPessoa.BuscarId(id);
            if (_pessoa == null) return pessoa;
            _pessoa.AtriuirNome(pessoa.Nome);
            _pessoa.AtriuirCPF(pessoa.CPF);
            _pessoa.AtriuirDataNascimento(pessoa.DataNascimento);

            if (!_pessoa.Validar()) return _pessoa;
            if (ValidarRegrasDeDominio(_pessoa).ListaErros.Any()) return _pessoa;
            _repositoryPessoa.DetachAllEntities();
            _repositoryPessoa.Atualizar(_pessoa);
            _repositoryPessoa.Salvar();
            return pessoa;
        }


        public Pessoa AtivarPessoa(Guid id)
        {
            var pessoa = _repositoryPessoa.BuscarId(id);
            if (pessoa == null)
            {
                pessoa = new Pessoa();
                pessoa.ListaErros.Add("Pessoa não localizada.");
                return pessoa;
            }
            pessoa.Ativar();
            _repositoryPessoa.DetachAllEntities();
            _repositoryPessoa.Atualizar(pessoa);
            _repositoryPessoa.Salvar();
            return pessoa;
        }

        public Pessoa ExcluirPessoa(Guid id)
        {
            var pessoa = _repositoryPessoa.BuscarId(id);
            if (pessoa == null)
            {
                pessoa = new Pessoa();
                pessoa.ListaErros.Add("Pessoa não localizada.");
                return pessoa;
            }
            _repositoryPessoa.DetachAllEntities();
            _repositoryPessoa.Remover(pessoa);
            _repositoryPessoa.Salvar();
            return pessoa;
        }

        public Pessoa InativarPessoa(Guid id)
        {
            var pessoa = _repositoryPessoa.BuscarId(id);
            if (pessoa == null)
            {
                pessoa = new Pessoa();
                pessoa.ListaErros.Add("Pessoa não localizada.");
                return pessoa;
            }
            pessoa.Inativar();
            _repositoryPessoa.DetachAllEntities();
            _repositoryPessoa.Atualizar(pessoa);
            _repositoryPessoa.Salvar();
            return pessoa;
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

        public IEnumerable<Telefone> ObterTelefonesDaPessoa(Guid idpessoa)
        {
            return _repositoryTelefone.Listar().Where(x => x.PessoaId == idpessoa);
        }

        public Telefone AdicionarTelefone(Telefone fone, Guid idpessoa)
        {
            fone.AtribuirIdPessoa(idpessoa);
            if (!fone.Validar()) return fone;
            if (VerificarSeTelefoneJaExiste(fone)) 
            { 
                fone.ListaErros.Add($"O telefone {fone.Numero} já existe para esta pessoa." );
                return fone;
            }
            _repositoryTelefone.Adicionar(fone);
            _repositoryPessoa.Salvar();
            return fone;
        }

        public Telefone AlterarTelefone(Telefone fone)
        {
            var telefone = _repositoryTelefone.BuscarId(fone.Id);
            if (telefone == null) return fone;
            telefone.AtribuirTipo(fone.Tipo);
            telefone.AtribuirNumero(fone.Numero);
            if (!telefone.Validar()) return telefone;
            _repositoryTelefone.DetachAllEntities();
            _repositoryTelefone.Atualizar(telefone);
            _repositoryTelefone.Salvar();
            return fone;
        }

        public Telefone ExcluirTelefone(Guid idtelefone)
        {
            var fone = _repositoryTelefone.BuscarId(idtelefone);
            if (fone == null)
            {
                fone = new Telefone();
                fone.ListaErros.Add($"Telefone não localizado");
                return fone;
            }
            _repositoryTelefone.DetachAllEntities();
            _repositoryTelefone.Remover(fone);
            _repositoryTelefone.Salvar();
            return fone;
        }

        private bool VerificarSeTelefoneJaExiste(Telefone telefone)
        {
            return _repositoryTelefone.Listar().Where(t => t.Numero == telefone.Numero && t.PessoaId == telefone.PessoaId).Any();
        }

        private bool VerificarSeCPFJaExiste(Pessoa pessoa)
        {
            return _repositoryPessoa.Listar().Where(p => p.CPF == pessoa.CPF && p.Id != pessoa.Id).Any();
        }

        private bool NaoAdicionouTodosOsTelefones(Pessoa pessoa)
        {
            foreach (var telefone in pessoa.ListaTelefones)
            {
                if (telefone.Validar())
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
            if (VerificarSeCPFJaExiste(pessoa)) pessoa.ListaErros.Add($"O CPF {pessoa.CPF} já existe para outra pessoa.");
            return pessoa;
        }

    }
}

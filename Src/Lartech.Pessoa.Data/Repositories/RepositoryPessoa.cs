using Dapper;
using Lartech.Domain.DTOS;
using Lartech.Domain.Entidades;
using Lartech.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Lartech.Data.Repositories
{
    public class RepositoryPessoa : Repository<Pessoa>, IRepositoryPessoa
    {

        public RepositoryPessoa(DataContext context) : base(context)
        {

        }

        public PessoaViewModel? ObterPorId(Guid id)
        {
            StringBuilder query = new StringBuilder();

            query.Append(@$" SELECT DISTINCT p.Id, 
                                   p.Nome,
                                   p.CPF,
                                   p.DataNascimento,
                                   p.Ativo,
                                   t.Numero,
                                   t.Tipo
                                   FROM Pessoas p WITH(NOLOCK) 
							LEFT JOIN Telefones t  WITH(NOLOCK) ON (p.Id = t.PessoaId)
                            WHERE p.ID = @ID
							ORDER BY p.Nome
                          ");

            var retorno = _context.Database.GetDbConnection().Query<PessoaDTO>(query.ToString(), new { ID = id }).ToList();
            var pessoaViewModel = TransformarDTO(retorno).FirstOrDefault();
            return pessoaViewModel;

        }



        public IEnumerable<PessoaViewModel> ObterTodos()
        {
            StringBuilder query = new StringBuilder();

            query.Append(@$" SELECT DISTINCT p.Id, 
                                   p.Nome,
                                   p.CPF,
                                   p.DataNascimento,
                                   p.Ativo,
                                   t.Numero,
                                   t.Tipo
                                   FROM Pessoas p WITH(NOLOCK) 
							LEFT JOIN Telefones t  WITH(NOLOCK) ON (p.Id = t.PessoaId)
							ORDER BY p.Nome
                          ");

            var retorno = _context.Database.GetDbConnection().Query<PessoaDTO>(query.ToString()).ToList();
            var pessoaViewModel = TransformarDTO(retorno);
            return pessoaViewModel;
        }

        public IEnumerable<PessoaViewModel> ObterAtivos()
        {
            StringBuilder query = new StringBuilder();

            query.Append(@$" SELECT DISTINCT p.Id, 
                                   p.Nome,
                                   p.CPF,
                                   p.DataNascimento,
                                   p.Ativo,
                                   t.Numero,
                                   t.Tipo
                                   FROM Pessoas p WITH(NOLOCK) 
							LEFT JOIN Telefones t  WITH(NOLOCK) ON (p.Id = t.PessoaId)
                            WHERE p.Ativo = 1
							ORDER BY p.Nome
                          ");

            var retorno = _context.Database.GetDbConnection().Query<PessoaDTO>(query.ToString()).ToList();
            var pessoaViewModel = TransformarDTO(retorno);
            return pessoaViewModel;
        }

        public IEnumerable<PessoaViewModel> ObterInativos()
        {
            StringBuilder query = new StringBuilder();

            query.Append(@$" SELECT DISTINCT p.Id, 
                                   p.Nome,
                                   p.CPF,
                                   p.DataNascimento,
                                   p.Ativo,
                                   t.Numero,
                                   t.Tipo
                                   FROM Pessoas p WITH(NOLOCK) 
							LEFT JOIN Telefones t  WITH(NOLOCK) ON (p.Id = t.PessoaId)
                            WHERE p.Ativo = 0
							ORDER BY p.Nome
                          ");

            var retorno = _context.Database.GetDbConnection().Query<PessoaDTO>(query.ToString()).ToList();
            var pessoaViewModel = TransformarDTO(retorno);
            return pessoaViewModel;
        }


        public PessoaViewModel? ObterPorCpf(string cpf)
        {
            StringBuilder query = new StringBuilder();

            query.Append(@$" SELECT DISTINCT p.Id, 
                                   p.Nome,
                                   p.CPF,
                                   p.DataNascimento,
                                   p.Ativo,
                                   t.Numero,
                                   t.Tipo
                                   FROM Pessoas p WITH(NOLOCK) 
							LEFT JOIN Telefones t  WITH(NOLOCK) ON (p.Id = t.PessoaId)
                            WHERE p.CPF = @CPF
							ORDER BY p.Nome
                          ");

            var retorno = _context.Database.GetDbConnection().Query<PessoaDTO>(query.ToString(), new { CPF = cpf }).ToList();
            var pessoaViewModel = TransformarDTO(retorno).FirstOrDefault();
            return pessoaViewModel;

        }

        public IEnumerable<PessoaViewModel> ObterPorParteDoNome(string nome)
        {
            StringBuilder query = new StringBuilder();

            query.Append(@$" SELECT DISTINCT p.Id, 
                                   p.Nome,
                                   p.CPF,
                                   p.DataNascimento,
                                   p.Ativo,
                                   t.Numero,
                                   t.Tipo
                                   FROM Pessoas p WITH(NOLOCK) 
							LEFT JOIN Telefones t  WITH(NOLOCK) ON (p.Id = t.PessoaId)
                            WHERE p.Nome LIKE @NOME
							ORDER BY p.Nome
                          ");

            var retorno = _context.Database.GetDbConnection().Query<PessoaDTO>(query.ToString(), new { NOME = "%" + nome + "%" }).ToList();
            var pessoaViewModel = TransformarDTO(retorno);
            return pessoaViewModel;
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


        private List<PessoaViewModel> TransformarDTO(List<PessoaDTO> dto)
        {
            var retorno = new List<PessoaViewModel>();
            foreach (var dtoItem in dto) 
            {
                var pessoa = retorno.Where(x => x.Id == dtoItem.Id).FirstOrDefault();
                if (pessoa == null)
                {
                    var item = new PessoaViewModel();
                    item.Id = dtoItem.Id;
                    item.Nome = dtoItem.Nome;
                    item.CPF = dtoItem.CPF;
                    item.DataNascimento = dtoItem.DataNascimento;
                    item.Ativo = dtoItem.Ativo;
                    item.Telefones.Add(new TelefoneDTO
                    {
                        Tipo = dtoItem.Tipo,
                        Numero = dtoItem.Numero
                    });
                    retorno.Add(item);
                }
                else
                {
                    pessoa.Telefones.Add(new TelefoneDTO
                    {
                        Tipo = dtoItem.Tipo,
                        Numero = dtoItem.Numero
                    });
                }
            }
            return retorno;
        }
    }
}

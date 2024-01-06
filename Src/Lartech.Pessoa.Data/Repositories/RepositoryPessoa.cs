using Dapper;
using Lartech.Domain.DTOS;
using Lartech.Domain.Entidades;
using Lartech.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Security.Cryptography;
using System.Text;

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

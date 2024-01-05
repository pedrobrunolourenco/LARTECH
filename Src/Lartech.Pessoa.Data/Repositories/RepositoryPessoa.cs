using Lartech.Domain.Entidades;
using Lartech.Domain.Interfaces.Repository;

namespace Lartech.Data.Repositories
{
    public class RepositoryPessoa : Repository<Pessoa>, IRepositoryPessoa
    {

        public RepositoryPessoa(DataContext context) : base(context)
        {

        }

    }
}

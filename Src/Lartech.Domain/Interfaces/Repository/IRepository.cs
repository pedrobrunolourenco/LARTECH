using Lartech.Domain.Entidades;

namespace Lartech.Domain.Interfaces.Repository
{
    public interface IRepository<TEntidade> : IDisposable where TEntidade : Entity
    {
        void DetachAllEntities();
        IEnumerable<TEntidade> Listar();
        TEntidade BuscarId(Guid id);
        void Adicionar(TEntidade obj);
        void Atualizar(TEntidade obj);
        void Remover(TEntidade obj);
        void Salvar();
    }
}

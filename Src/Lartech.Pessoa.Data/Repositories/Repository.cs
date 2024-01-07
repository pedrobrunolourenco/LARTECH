using Lartech.Domain.Entidades;
using Lartech.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lartech.Data.Repositories
{
    public class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : Entity
    {

        protected DataContext _context;
        protected DbSet<TEntidade> DbSet;

        public Repository(DataContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntidade>();
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = _context.ChangeTracker.Entries().ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

        public TEntidade BuscarId(Guid id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntidade> Listar()
        {
            return DbSet.ToList();
        }

        public void Adicionar(TEntidade obj)
        {
            DbSet.Add(obj);
        }

        public void Atualizar(TEntidade obj)
        {
            DbSet.Update(obj);
        }

        public void Remover(TEntidade obj)
        {
            DbSet.Remove(obj);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }

}

using Lartech.Domain.Entidades;
using Lartech.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lartech.Data.Repositories
{
    public class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : Entity
    {

        protected DataContext Db;
        protected DbSet<TEntidade> DbSet;

        public Repository(DataContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntidade>();
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = Db.ChangeTracker.Entries().ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }


        public IEnumerable<TEntidade> Listar()
        {
            return DbSet.ToList();
        }

        public TEntidade ObterPorId(Guid id)
        {
            return DbSet.Find(id); ;
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
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }

}

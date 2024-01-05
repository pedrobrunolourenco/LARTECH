using Lartech.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lartech.Domain.Interfaces.Repository
{
    public interface IRepository<TEntidade> : IDisposable where TEntidade : Entity
    {
        void DetachAllEntities();
        IEnumerable<TEntidade> Listar();
        TEntidade ObterPorId(Guid id);
        void Adicionar(TEntidade obj);
        void Atualizar(TEntidade obj);
        void Remover(TEntidade obj);
        void Salvar();
    }
}

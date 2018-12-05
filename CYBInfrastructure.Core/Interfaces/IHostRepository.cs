using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Interfaces
{
      public interface IHostRepository
    {
        IEnumerable<Host> OrderBy(Expression<Func<Host, bool>> predicate);

        Host Get(int id);
        IEnumerable<Host> GetAll();
        IEnumerable<Host> Find(Expression<Func<Host, bool>> predicate);
        void Add(Host entity);
        void Edit(Host entity);
        void AddRange(IEnumerable<Host> entities);
        void Remove(Host entity);
        void SaveChanges();

        void RemoveRange(IEnumerable<Host> entities);
    }
}

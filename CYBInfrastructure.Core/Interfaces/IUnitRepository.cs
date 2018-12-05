using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Interfaces
{
    public interface IUnitRepository
    {
         IEnumerable<Unit> OrderBy(Expression<Func<Unit, bool>> predicate);

         Unit Get(int id);
         IEnumerable<Unit> GetAll();
         IEnumerable<Unit> Find(Expression<Func<Unit, bool>> predicate);
         void Add(Unit entity);
         void Edit(Unit entity);
         void AddRange(IEnumerable<Unit> entities);
         void Remove(Unit entity);
        void SaveChanges();

         void RemoveRange(IEnumerable<Unit> entities);
    }
}

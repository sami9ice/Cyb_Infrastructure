using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Interfaces
{
   public interface IServiceRepository
    {
        IEnumerable<Services> OrderBy(Expression<Func<Services, bool>> predicate);

        Services Get(int id);
        IEnumerable<Services> GetAll();
        IEnumerable<Services> Find(Expression<Func<Services, bool>> predicate);
        void Add(Services entity);
        void Edit(Services entity);
        void AddRange(IEnumerable<Services> entities);
        void Remove(Services entity);
        void SaveChanges();

        void RemoveRange(IEnumerable<Services> entities);
    }
}

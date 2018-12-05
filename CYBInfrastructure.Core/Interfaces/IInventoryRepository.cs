using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Interfaces
{
   public interface IInventoryRepository
   {
        IEnumerable<Inventory> OrderBy(Expression<Func<Inventory, bool>> predicate);

        Inventory Get(int id);
        IEnumerable<Inventory> GetAll();
        IEnumerable<Inventory> Find(Expression<Func<Inventory, bool>> predicate);
        //IEnumerable<Inventory> Any(Expression<Func<Inventory, bool>> predicate);

        void Add(Inventory entity);
        void Edit(Inventory entity);
        void AddRange(IEnumerable<Inventory> entities);
        void Remove(Inventory entity);
        void SaveChanges();

        void RemoveRange(IEnumerable<Inventory> entities);
    }
}

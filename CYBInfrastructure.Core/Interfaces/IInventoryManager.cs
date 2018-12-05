using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Interfaces
{
    public interface IInventoryManager
    {
        Inventory Get(int id);

        IEnumerable<Inventory> GetAll();

        IEnumerable<Inventory> Find(Expression<Func<Inventory, bool>> predicate);
        IEnumerable<Inventory> SelectList(Expression<Func<Inventory, bool>> predicate);

        //IEnumerable<Inventory> Any (Expression<Func<Inventory, bool>> predicate);

        IEnumerable<Inventory> Order(Expression<Func<Inventory, bool>> predicate);
        //IEnumerable<Inventory> Any(Expression<Func<Inventory, bool>> predicate);


        void Add(Inventory entity);


        void Edit(Inventory entity);


        void AddRange(IEnumerable<Inventory> entities);

        void Remove(Inventory entity);

        void RemoveRange(IEnumerable<Inventory> entities);

        void SaveChanges();
        //bool Any(Expression<Func<Inventory, bool>> predicate);
    }
}

using CYBInfracstructure.DataStructure;
using CYBInfracstructure.DataStructure.Entities;
using CYBInfrastructure.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly CYBInfrastrctureContext context;
        public InventoryRepository(CYBInfrastrctureContext context)
        {
            this.context = context;
        }
       
        public void Add(Inventory entity)
        {
            context.Set<Inventory>().Add(entity);
        }

        public void AddRange(IEnumerable<Inventory> entities)
        {
            context.Set<Inventory>().AddRange(entities);
        }

        public void Edit(Inventory entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }

        public IEnumerable<Inventory> Find(Expression<Func<Inventory, bool>> predicate)
        {
            return context.Set<Inventory>().Where(predicate);
        }

        public Inventory Get(int id)
        {
            return context.Set<Inventory>().Find(id);
        }

        public IEnumerable<Inventory> GetAll()
        {
            return context.Set<Inventory>().ToList();
        }

        public IEnumerable<Inventory> OrderBy(Expression<Func<Inventory, bool>> predicate)
        {
            return context.Set<Inventory>().OrderBy(predicate);
        }
        //public IEnumerable<Inventory> Any(Expression<Func<Inventory, bool>> predicate)
        //{
        //    return context.Set<Inventory>().Any(x => x.ServerName   );
        //}

        public void Remove(Inventory entity)
        {
            context.Set<Inventory>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Inventory> entities)
        {
            context.Set<Inventory>().RemoveRange(entities);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

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
    public class UnitRepository : IUnitRepository
    {
        private readonly CYBInfrastrctureContext context;
        public UnitRepository(CYBInfrastrctureContext context)
        {
            this.context = context;
        }
        public void Add(Unit entity)
        {
            context.Set<Unit>().Add(entity);
        }

        public void AddRange(IEnumerable<Unit> entities)
        {
            context.Set<Unit>().AddRange(entities);
        }

        public void Edit(Unit entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }

        public IEnumerable<Unit> Find(Expression<Func<Unit, bool>> predicate)
        {
            return context.Set<Unit>().Where(predicate);
        }

        public Unit Get(int id)
        {
            return context.Set<Unit>().Find(id);
        }

        public IEnumerable<Unit> GetAll()
        {
            return context.Set<Unit>().ToList();
        }

        public IEnumerable<Unit> OrderBy(Expression<Func<Unit, bool>> predicate)
        {
            return context.Set<Unit>().OrderBy(predicate);
        }

        public void Remove(Unit entity)
        {
            context.Set<Unit>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Unit> entities)
        {
            context.Set<Unit>().RemoveRange(entities);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

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
   public class HostRepository:IHostRepository
    {
        private readonly CYBInfrastrctureContext context;
        public HostRepository(CYBInfrastrctureContext context)
        {
            this.context = context;
        }
        public void Add(Host entity)
        {
            context.Set<Host>().Add(entity);
        }

        public void AddRange(IEnumerable<Host> entities)
        {
            context.Set<Host>().AddRange(entities);
        }

        public void Edit(Host entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }

        public IEnumerable<Host> Find(Expression<Func<Host, bool>> predicate)
        {
            return context.Set<Host>().Where(predicate);
        }

        public Host Get(int id)
        {
            return context.Set<Host>().Find(id);
        }

        public IEnumerable<Host> GetAll()
        {
            return context.Set<Host>().ToList();
        }

        public IEnumerable<Host> OrderBy(Expression<Func<Host, bool>> predicate)
        {
            return context.Set<Host>().OrderBy(predicate);
        }

        public void Remove(Host entity)
        {
            context.Set<Host>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Host> entities)
        {
            context.Set<Host>().RemoveRange(entities);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

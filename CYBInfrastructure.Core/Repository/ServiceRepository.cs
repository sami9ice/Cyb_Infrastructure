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
    public class ServiceRepository : IServiceRepository
    {
        private readonly CYBInfrastrctureContext context;
        public ServiceRepository(CYBInfrastrctureContext context)
        {
            this.context = context;
        }
        public void Add(Services entity)
        {
            context.Set<Services>().Add(entity);
        }

        public void AddRange(IEnumerable<Services> entities)
        {
            context.Set<Services>().AddRange(entities);
        }

        public void Edit(Services entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }
       
        public IEnumerable<Services> Find(Expression<Func<Services, bool>> predicate)
        {
          return  context.Set<Services>().Where(predicate);
        }

        public Services Get(int id)
        {
            return context.Set<Services>().Find(id);
        }

        public IEnumerable<Services> GetAll()
        {
            return context.Set<Services>().ToList();
        }

        public IEnumerable<Services> OrderBy(Expression<Func<Services, bool>> predicate)
        {
            return context.Set<Services>().OrderBy(predicate);
        }

        public void Remove(Services entity)
        {
            context.Set<Services>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Services> entities)
        {
            context.Set<Services>().RemoveRange(entities);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

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
    public class LocationRepository : ILocationRepository
    {
        private readonly CYBInfrastrctureContext context;
        public LocationRepository(CYBInfrastrctureContext context)
        {
            this.context = context;
        }
        public void Add(Location entity)
        {
            context.Set<Location>().Add(entity);
        }

        public void AddRange(IEnumerable<Location> entities)
        {
            context.Set<Location>().AddRange(entities);
        }

        public void Edit(Location entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }

        public IEnumerable<Location> Find(Expression<Func<Location, bool>> predicate)
        {
            return context.Set<Location>().Where(predicate);
        }

        public Location Get(int id)
        {
            return context.Set<Location>().Find(id);
        }

        public IEnumerable<Location> GetAll()
        {
            return context.Set<Location>().ToList();
        }

        public IEnumerable<Location> OrderBy(Expression<Func<Location, bool>> predicate)
        {
            return context.Set<Location>().OrderBy(predicate);
        }

        public IEnumerable<Location> SelectList(Expression<Func<Location, bool>> predicate)
        {
            return context.Set<Location>().Where(predicate);
        }
        public void Remove(Location entity)
        {
            context.Set<Location>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Location> entities)
        {
            context.Set<Location>().RemoveRange(entities);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

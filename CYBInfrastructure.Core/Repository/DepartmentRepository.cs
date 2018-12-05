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
    public class DepartmentRepository : IDepartmentRepository

    {
        private readonly CYBInfrastrctureContext context;
          public DepartmentRepository(CYBInfrastrctureContext context)
        {
           this.context = context;     
        }


        public void Add(Department entity)
        {
            context.Set<Department>().Add(entity);
        }

        public void AddRange(IEnumerable<Department> entities)
        {
            context.Set<Department>().AddRange(entities);
        }

        public void Edit(Department entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }

        public IEnumerable<Department> Find(Expression<Func<Department, bool>> predicate)
        {
            return context.Set<Department>().Where(predicate);
        }

        public Department Get(int id)
        {
            return context.Set<Department>().Find(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return context.Set<Department>().ToList();
        }

        public IEnumerable<Department> OrderBy(Expression<Func<Department, bool>> predicate)
        {
            return context.Set<Department>().OrderBy(predicate);
        }

        public void Remove(Department entity)
        {
            context.Set<Department>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Department> entities)
        {
            context.Set<Department>().RemoveRange(entities);
        }

      

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

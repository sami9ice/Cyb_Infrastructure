using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CYBInfracstructure.DataStructure.Entities;


namespace CYBInfrastructure.Core.Interfaces
{
    public interface  IDepartmentRepository
    {
        IEnumerable<Department> OrderBy(Expression<Func<Department, bool>> predicate);
        Department Get(int id);
        IEnumerable<Department> GetAll();
        IEnumerable<Department> Find(Expression<Func<Department, bool>> predicate);
        void Add(Department entity);
        void Edit(Department entity);
        void AddRange(IEnumerable<Department> entities);
        void Remove(Department entity);
        void SaveChanges();
        void RemoveRange(IEnumerable<Department> entities);

    }
}

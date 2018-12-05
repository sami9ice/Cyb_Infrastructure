using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Interfaces
{
    public interface IDepartmentManager
    {
        Department Get(int id);

        IEnumerable<Department> GetAll();

        IEnumerable<Department> Find(Expression<Func<Department, bool>> predicate);
        IEnumerable<Department> SelectList(Expression<Func<Department, bool>> predicate);


        IEnumerable<Department> Order(Expression<Func<Department, bool>> predicate);

        void Add(Department entity);


        void Edit(Department entity);


        void AddRange(IEnumerable<Department> entities);

        void Remove(Department entity);

        void RemoveRange(IEnumerable<Department> entities);

        void SaveChanges();
    }
}

using CYBInfracstructure.DataStructure;
using CYBInfracstructure.DataStructure.Entities;
using CYBInfrastructure.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Managers
{

    public class DepartmentManager:IDepartmentManager
    {

        private readonly IDepartmentRepository _departmentrepository;


        public DepartmentManager(IDepartmentRepository _departmentrepository)
        {
            this._departmentrepository = _departmentrepository;

        }

        public Department Get(int id)
        {

            return _departmentrepository.Get(id);
        }
        public IEnumerable<Department> GetAll()
        {
            return _departmentrepository.GetAll().ToList();
        }
        public IEnumerable<Department> Find(Expression<Func<Department, bool>> predicate)
        {
            Expression<Func<Department, bool>> predicate1 = predicate;
            return _departmentrepository.Find(predicate1);
        }

        public IEnumerable<Department> Order(Expression<Func<Department, bool>> predicate)
        {
            return _departmentrepository.OrderBy(predicate);
        }
        public void Add(Department entity)

        {
            _departmentrepository.Add(entity);
            SaveChanges();
        }

        public void Edit(Department entity)
        {
            _departmentrepository.Edit(entity);
            SaveChanges();
        }

        public void AddRange(IEnumerable<Department> entities)
        {
            _departmentrepository.AddRange(entities);
        }
        public void Remove(Department entity)
        {
            _departmentrepository.Remove(entity);
            SaveChanges();
        }
        public void RemoveRange(IEnumerable<Department> entities)
        {
            _departmentrepository.RemoveRange(entities);
        }
        public void SaveChanges()
        {
            _departmentrepository.SaveChanges();
        }

        public IEnumerable<Department> SelectList(Expression<Func<Department, bool>> predicate)
        {
            return _departmentrepository.Find(predicate);
        }
    }
}

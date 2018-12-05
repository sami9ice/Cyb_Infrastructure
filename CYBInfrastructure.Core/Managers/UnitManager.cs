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
    public class UnitManager:IUnitManager
    {

        private readonly IUnitRepository _unitrepository;
        public UnitManager(IUnitRepository _unitrepository)
        {
            this._unitrepository = _unitrepository;
        }
        public  Unit Get(int id)
        {

            return _unitrepository.Get(id);
        }
        public  IEnumerable<Unit> GetAll()
        {
            return _unitrepository.GetAll();
        }
        public  IEnumerable<Unit> Find(Expression<Func<Unit, bool>> predicate)
        {
            Expression<Func<Unit, bool>> predicate1 = predicate;
            return _unitrepository.Find(predicate1);
        }

        public IEnumerable<Unit> Order(Expression<Func<Unit, bool>> predicate)
        {
            return _unitrepository.OrderBy(predicate);
        }
        public  void Add(Unit entity)

        {
            _unitrepository.Add(entity);
            SaveChanges();
        }

        public  void Edit(Unit entity)
        {
            _unitrepository.Edit(entity);
            SaveChanges();
        }

        public  void AddRange(IEnumerable<Unit> entities)
        {
            _unitrepository.AddRange(entities);
        }
        public  void Remove(Unit entity)
        {
            _unitrepository.Remove(entity);
            SaveChanges();
        }
        public  void RemoveRange(IEnumerable<Unit> entities)
        {
            _unitrepository.RemoveRange(entities);
        }
        public  void SaveChanges()
        {
            _unitrepository.SaveChanges();
        }
        public IEnumerable<Unit> SelectList(Expression<Func<Unit, bool>> predicate)
        {
            return _unitrepository.Find(predicate);

        }
    }
}

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
    public class HostManager:IHostManager
    {
        private readonly IHostRepository _hostrepository;
        public HostManager(IHostRepository _hostrepository)
        {
            this._hostrepository = _hostrepository;
        }
        public Host Get(int id)
        {

            return _hostrepository.Get(id);
        }
        public IEnumerable<Host> GetAll()
        {
            return _hostrepository.GetAll();
        }
        public IEnumerable<Host> Find(Expression<Func<Host, bool>> predicate)
        {
            Expression<Func<Host, bool>> predicate1 = predicate;
            return _hostrepository.Find(predicate1);
        }

        public IEnumerable<Host> Order(Expression<Func<Host, bool>> predicate)
        {
            return _hostrepository.OrderBy(predicate);
        }
        public void Add(Host entity)

        {
            _hostrepository.Add(entity);
            SaveChanges();
        }

        public void Edit(Host entity)
        {
            _hostrepository.Edit(entity);
            SaveChanges();
        }

        public void AddRange(IEnumerable<Host> entities)
        {
            _hostrepository.AddRange(entities);
        }
        public void Remove(Host entity)
        {
            _hostrepository.Remove(entity);
            SaveChanges();
        }
        public void RemoveRange(IEnumerable<Host> entities)
        {
            _hostrepository.RemoveRange(entities);
        }
        public void SaveChanges()
        {
            _hostrepository.SaveChanges();
        }
        public IEnumerable<Host> SelectList(Expression<Func<Host, bool>> predicate)
        {
            return _hostrepository.Find(predicate);

        }
    }
}

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
     public  class CredManager:ICredManager
    {
        private readonly ICredRepository _credrepository;


        public CredManager(ICredRepository _credrepository)
        {
            this._credrepository = _credrepository;

        }

        public CredentialSetup Get(int id)
        {

            return _credrepository.Get(id);
        }
        public IEnumerable<CredentialSetup> GetAll()
        {
            return _credrepository.GetAll().ToList();
        }
        public IEnumerable<CredentialSetup> Find(Expression<Func<CredentialSetup, bool>> predicate)
        {
            Expression<Func<CredentialSetup, bool>> predicate1 = predicate;
            return _credrepository.Find(predicate1);
        }

        public IEnumerable<CredentialSetup> Order(Expression<Func<CredentialSetup, bool>> predicate)
        {
            return _credrepository.OrderBy(predicate);
        }
        public void Add(CredentialSetup entity)

        {
            _credrepository.Add(entity);
            SaveChanges();
        }

        public void Edit(CredentialSetup entity)
        {
            _credrepository.Edit(entity);
            SaveChanges();
        }

        public void AddRange(IEnumerable<CredentialSetup> entities)
        {
            _credrepository.AddRange(entities);
        }
        public void Remove(CredentialSetup entity)
        {
            _credrepository.Remove(entity);
            SaveChanges();
        }
        public void RemoveRange(IEnumerable<CredentialSetup> entities)
        {
            _credrepository.RemoveRange(entities);
        }
        public void SaveChanges()
        {
            _credrepository.SaveChanges();
        }

        public IEnumerable<CredentialSetup> SelectList(Expression<Func<CredentialSetup, bool>> predicate)
        {
            return _credrepository.Find(predicate);
        }
    }
}

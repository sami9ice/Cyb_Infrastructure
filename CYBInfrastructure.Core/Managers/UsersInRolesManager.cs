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
     public  class UsersInRolesManager:IUsersInRoleManager
    {

        private readonly IUsersInRoleRepository _roleRepo;
        public UsersInRolesManager(IUsersInRoleRepository _roleRepo)
        {
            this._roleRepo = _roleRepo;
        }
        public UsersInRoles Get(int id)
        {

            return _roleRepo.Get(id);
        }
        public IEnumerable<UsersInRoles> GetAll()
        {
            return _roleRepo.GetAll();
        }
        public IEnumerable<UsersInRoles> Find(Expression<Func<UsersInRoles, bool>> predicate)
        {
            Expression<Func<UsersInRoles, bool>> predicate1 = predicate;
            return _roleRepo.Find(predicate1);
        }

        public IEnumerable<UsersInRoles> Order(Expression<Func<UsersInRoles, bool>> predicate)
        {
            return _roleRepo.OrderBy(predicate);
        }
        public IEnumerable<UsersInRoles> SelectList(Expression<Func<UsersInRoles, bool>> predicate)
        {
            return _roleRepo.SelectList(predicate);

        }

        public void Add(UsersInRoles entity)

        {
            _roleRepo.Add(entity);
            SaveChanges();
        }


        public void Edit(UsersInRoles entity)
        {
            _roleRepo.Edit(entity);
            SaveChanges();
        }

        public void AddRange(IEnumerable<UsersInRoles> entities)
        {
            _roleRepo.AddRange(entities);
        }
        public void Remove(UsersInRoles entity)
        {
            _roleRepo.Remove(entity);
            SaveChanges();
        }
        public void RemoveRange(IEnumerable<UsersInRoles> entities)
        {
            _roleRepo.RemoveRange(entities);
        }
        public void SaveChanges()
        {
            _roleRepo.SaveChanges();
        }
    }
}

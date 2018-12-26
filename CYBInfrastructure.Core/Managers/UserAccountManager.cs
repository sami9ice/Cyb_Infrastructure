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
   public class UserAccountManager:IUserAccountManager
    {
        private readonly IUserAccountRepository UserRepo;
        public UserAccountManager(IUserAccountRepository UserRepo)
        {
            this.UserRepo = UserRepo;
        }
        public UserAccount Get(int id)
        {

            return UserRepo.Get(id);
        }
        public IEnumerable<UserAccount> GetAll()
        {
            return UserRepo.GetAll();
        }
        public IEnumerable<UserAccount> Find(Expression<Func<UserAccount, bool>> predicate)
        {
            Expression<Func<UserAccount, bool>> predicate1 = predicate;
            return UserRepo.Find(predicate1);
        }

        public IEnumerable<UserAccount> Order(Expression<Func<UserAccount, bool>> predicate)
        {
            return UserRepo.OrderBy(predicate);
        }
        public IEnumerable<UserAccount> SelectList(Expression<Func<UserAccount, bool>> predicate)
        {
            return UserRepo.SelectList(predicate);

        }

        public void Add(UserAccount entity)

        {
            UserRepo.Add(entity);
            SaveChanges();
        }


        public void Edit(UserAccount entity)
        {
            UserRepo.Edit(entity);
            SaveChanges();
        }

        public void AddRange(IEnumerable<UserAccount> entities)
        {
            UserRepo.AddRange(entities);
        }
        public void Remove(UserAccount entity)
        {
            UserRepo.Remove(entity);
            SaveChanges();
        }
        public void RemoveRange(IEnumerable<UserAccount> entities)
        {
            UserRepo.RemoveRange(entities);
        }
        public void SaveChanges()
        {
            UserRepo.SaveChanges();
        }
    }
}

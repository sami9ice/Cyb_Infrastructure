using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Interfaces
{
    public interface IUserAccountRepository
    {
        UserAccount Get(int id);
        IEnumerable<UserAccount> GetAll();
        IEnumerable<UserAccount> Find(Expression<Func<UserAccount, bool>> predicate);
        IEnumerable<UserAccount> SelectList(Expression<Func<UserAccount, bool>> predicate);
        IEnumerable<UserAccount> OrderBy(Expression<Func<UserAccount, bool>> predicate);


        void Add(UserAccount entity);
        void Edit(UserAccount entity);
        void AddRange(IEnumerable<UserAccount> entities);
        void Remove(UserAccount entity);
        void SaveChanges();

        void RemoveRange(IEnumerable<UserAccount> entities);
    }
}

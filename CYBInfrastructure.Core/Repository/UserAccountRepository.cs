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
    public class UserAccountRepository: IUserAccountRepository
    {
        private readonly CYBInfrastrctureContext context;
        public UserAccountRepository(CYBInfrastrctureContext context)
        {
            this.context = context;
        }
        public void Add(UserAccount entity)
        {
            context.Set<UserAccount>().Add(entity);
        }

        public void AddRange(IEnumerable<UserAccount> entities)
        {
            context.Set<UserAccount>().AddRange(entities);
        }

        public void Edit(UserAccount entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }

        public IEnumerable<UserAccount> Find(Expression<Func<UserAccount, bool>> predicate)
        {
            return context.Set<UserAccount>().Where(predicate);
        }
        public IEnumerable<UserAccount> SelectList(Expression<Func<UserAccount, bool>> predicate)
        {
            return context.Set<UserAccount>().Where(predicate);

        }

        public UserAccount Get(int id)
        {
            return context.Set<UserAccount>().Find(id);
        }

        public IEnumerable<UserAccount> GetAll()
        {
            return context.Set<UserAccount>().ToList();
        }

        public IEnumerable<UserAccount> OrderBy(System.Linq.Expressions.Expression<Func<UserAccount, bool>> predicate)
        {
            return context.Set<UserAccount>().OrderBy(predicate);
        }

        public void Remove(UserAccount entity)
        {
            context.Set<UserAccount>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<UserAccount> entities)
        {
            context.Set<UserAccount>().RemoveRange(entities);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

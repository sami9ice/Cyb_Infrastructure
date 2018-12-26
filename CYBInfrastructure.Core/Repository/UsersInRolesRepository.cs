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
     public class UsersInRolesRepository:IUsersInRoleRepository
    {
        private readonly CYBInfrastrctureContext context;
        public UsersInRolesRepository(CYBInfrastrctureContext context)
        {
            this.context = context;
        }
        public void Add(UsersInRoles entity)
        {
            context.Set<UsersInRoles>().Add(entity);
        }

        public void AddRange(IEnumerable<UsersInRoles> entities)
        {
            context.Set<UsersInRoles>().AddRange(entities);
        }

        public void Edit(UsersInRoles entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }

        public IEnumerable<UsersInRoles> Find(Expression<Func<UsersInRoles, bool>> predicate)
        {
            return context.Set<UsersInRoles>().Where(predicate);
        }
        public IEnumerable<UsersInRoles> SelectList(Expression<Func<UsersInRoles, bool>> predicate)
        {
            return context.Set<UsersInRoles>().Where(predicate);

        }

        public UsersInRoles Get(int id)
        {
            return context.Set<UsersInRoles>().Find(id);
        }

        public IEnumerable<UsersInRoles> GetAll()
        {
            return context.Set<UsersInRoles>().ToList();
        }

        public IEnumerable<UsersInRoles> OrderBy(System.Linq.Expressions.Expression<Func<UsersInRoles, bool>> predicate)
        {
            return context.Set<UsersInRoles>().OrderBy(predicate);
        }

        public void Remove(UsersInRoles entity)
        {
            context.Set<UsersInRoles>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<UsersInRoles> entities)
        {
            context.Set<UsersInRoles>().RemoveRange(entities);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

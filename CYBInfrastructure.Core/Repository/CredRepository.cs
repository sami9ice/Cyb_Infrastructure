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
   public class CredRepository:ICredRepository
    {
        private readonly CYBInfrastrctureContext context;
        public CredRepository(CYBInfrastrctureContext context)
        {
            this.context = context;
        }


        public void Add(CredentialSetup entity)
        {
            context.Set<CredentialSetup>().Add(entity);
        }

        public void AddRange(IEnumerable<CredentialSetup> entities)
        {
            context.Set<CredentialSetup>().AddRange(entities);
        }

        public void Edit(CredentialSetup entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }

        public IEnumerable<CredentialSetup> Find(Expression<Func<CredentialSetup, bool>> predicate)
        {
            return context.Set<CredentialSetup>().Where(predicate);
        }

        public CredentialSetup Get(int id)
        {
            return context.Set<CredentialSetup>().Find(id);
        }

        public IEnumerable<CredentialSetup> GetAll()
        {
            return context.Set<CredentialSetup>().ToList();
        }

        public IEnumerable<CredentialSetup> OrderBy(Expression<Func<CredentialSetup, bool>> predicate)
        {
            return context.Set<CredentialSetup>().OrderBy(predicate);
        }

        public void Remove(CredentialSetup entity)
        {
            context.Set<CredentialSetup>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<CredentialSetup> entities)
        {
            context.Set<CredentialSetup>().RemoveRange(entities);
        }



        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Interfaces
{
   public interface ICredRepository
    {
        IEnumerable<CredentialSetup> OrderBy(Expression<Func<CredentialSetup, bool>> predicate);
        CredentialSetup Get(int id);
        IEnumerable<CredentialSetup> GetAll();
        IEnumerable<CredentialSetup> Find(Expression<Func<CredentialSetup, bool>> predicate);
        void Add(CredentialSetup entity);
        void Edit(CredentialSetup entity);
        void AddRange(IEnumerable<CredentialSetup> entities);
        void Remove(CredentialSetup entity);
        void SaveChanges();
        void RemoveRange(IEnumerable<CredentialSetup> entities);
    }
}

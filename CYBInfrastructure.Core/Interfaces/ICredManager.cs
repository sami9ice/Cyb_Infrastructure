using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Interfaces
{
    public interface ICredManager
    {
        CredentialSetup Get(int id);

        IEnumerable<CredentialSetup> GetAll();

        IEnumerable<CredentialSetup> Find(Expression<Func<CredentialSetup, bool>> predicate);
        IEnumerable<CredentialSetup> SelectList(Expression<Func<CredentialSetup, bool>> predicate);


        IEnumerable<CredentialSetup> Order(Expression<Func<CredentialSetup, bool>> predicate);

        void Add(CredentialSetup entity);


        void Edit(CredentialSetup entity);


        void AddRange(IEnumerable<CredentialSetup> entities);

        void Remove(CredentialSetup entity);

        void RemoveRange(IEnumerable<CredentialSetup> entities);

        void SaveChanges();
    }
}

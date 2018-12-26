﻿using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Interfaces
{
    public interface IUsersInRoleManager
    {
       UsersInRoles Get(int id);

        IEnumerable<UsersInRoles> GetAll();

        IEnumerable<UsersInRoles> Find(Expression<Func<UsersInRoles, bool>> predicate);
        IEnumerable<UsersInRoles> SelectList(Expression<Func<UsersInRoles, bool>> predicate);


        IEnumerable<UsersInRoles> Order(Expression<Func<UsersInRoles, bool>> predicate);

        void Add(UsersInRoles entity);


        void Edit(UsersInRoles entity);


        void AddRange(IEnumerable<UsersInRoles> entities);

        void Remove(UsersInRoles entity);

        void RemoveRange(IEnumerable<UsersInRoles> entities);

        void SaveChanges();
    }
}
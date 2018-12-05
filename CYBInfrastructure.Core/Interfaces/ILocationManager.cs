using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Interfaces
{
     public interface ILocationManager
    {
          Location Get(int id);

          IEnumerable<Location> GetAll();

          IEnumerable<Location> Find(Expression<Func<Location, bool>> predicate);
        IEnumerable<Location> SelectList(Expression<Func<Location, bool>> predicate);


        IEnumerable<Location> Order(Expression<Func<Location, bool>> predicate);

          void Add(Location entity);


          void Edit(Location entity);


          void AddRange(IEnumerable<Location> entities);

          void Remove(Location entity);

          void RemoveRange(IEnumerable<Location> entities);

          void SaveChanges();
    }
}


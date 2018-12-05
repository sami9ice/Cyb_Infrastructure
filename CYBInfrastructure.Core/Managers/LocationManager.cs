using CYBInfracstructure.DataStructure;
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
    public class LocationManager: ILocationManager
    { 

        private readonly ILocationRepository _locationrepository;
        public LocationManager(ILocationRepository _locationrepository)
        {
            this._locationrepository = _locationrepository;
        }
        public Location Get(int id)
        {

            return _locationrepository.Get(id);
        }
        public IEnumerable<Location> GetAll()
        {
            return _locationrepository.GetAll();
        }
        public IEnumerable<Location> Find(Expression<Func<Location, bool>> predicate)
        {
            Expression<Func<Location, bool>> predicate1 = predicate;
            return _locationrepository.Find(predicate1);
        }

        public IEnumerable<Location> Order(Expression<Func<Location, bool>> predicate)
        {
            return _locationrepository.OrderBy(predicate);
        }
        public IEnumerable<Location> SelectList(Expression<Func<Location, bool>> predicate)
        {
            return _locationrepository.SelectList(predicate);

        }

        public void Add(Location entity)

        {
        _locationrepository.Add(entity);
            SaveChanges();
        }

        public void Edit(Location entity)
        {
        _locationrepository.Edit(entity);
            SaveChanges();
        }

        public void AddRange(IEnumerable<Location> entities)
        {
        _locationrepository.AddRange(entities);
        }
        public void Remove(Location entity)
        {
        _locationrepository.Remove(entity);
            SaveChanges();
        }
        public void RemoveRange(IEnumerable<Location> entities)
        {
        _locationrepository.RemoveRange(entities);
        }
        public void SaveChanges()
        {
        _locationrepository.SaveChanges();
        }
    }
}

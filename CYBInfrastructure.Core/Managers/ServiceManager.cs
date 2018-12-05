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
    public class ServiceManager : IServiceManager
        
    {
        private readonly IServiceRepository serviceRepository;
        public ServiceManager(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }
       
        public void Add(Services entity)
        {
            serviceRepository.Add(entity);
            SaveChanges();
        }

        public void AddRange(IEnumerable<Services> entities)
        {
            serviceRepository.AddRange(entities);
            SaveChanges();
        }

        public void Edit(Services entity)
        {
            serviceRepository.Edit(entity);
            SaveChanges();
        }

        public IEnumerable<Services> Find(Expression<Func<Services, bool>> predicate)
        {

            Expression<Func<Services, bool>> predicate1 = predicate;
            return serviceRepository.Find(predicate1);
        }

        public Services Get(int id)
        {
            return serviceRepository.Get(id);
        }

        public IEnumerable<Services> GetAll()
        {
            return serviceRepository.GetAll();
        }

        public IEnumerable<Services> Order(Expression<Func<Services, bool>> predicate)
        {
            return serviceRepository.OrderBy(predicate);
        }

        public void Remove(Services entity)
        {
            serviceRepository.Remove(entity);
            SaveChanges();
        }

        public void RemoveRange(IEnumerable<Services> entities)
        {
            serviceRepository.RemoveRange(entities);
            SaveChanges();
        }

        public void SaveChanges()
        {
            serviceRepository.SaveChanges();
        }

        public IEnumerable<Services> SelectList(Expression<Func<Services, bool>> predicate)
        {
            return serviceRepository.Find(predicate);
        }
    }
}

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
    public class InventoryManager : IInventoryManager
    {
        private readonly IInventoryRepository inventoryRepository;
        public InventoryManager(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public void Add(Inventory entity)
        {
             inventoryRepository.Add(entity);
            SaveChanges();
        }

        public void AddRange(IEnumerable<Inventory> entities)
        {
            inventoryRepository.AddRange(entities);
            SaveChanges();
        }

        public void Edit(Inventory entity)
        {
            inventoryRepository.Edit(entity);
            SaveChanges();
        }

        public IEnumerable<Inventory> Find(Expression<Func<Inventory, bool>> predicate)
        {
            return inventoryRepository.Find(predicate);
        }

        public Inventory Get(int id)
        {
            return inventoryRepository.Get(id);
        }

        public IEnumerable<Inventory> GetAll()
        {
            return inventoryRepository.GetAll();
        }

        public IEnumerable<Inventory> Order(Expression<Func<Inventory, bool>> predicate)
        {
            return inventoryRepository.OrderBy(predicate);
        }

        public void Remove(Inventory entity)
        {
            inventoryRepository.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Inventory> entities)
        {
            inventoryRepository.RemoveRange(entities);
        }

        public void SaveChanges()
        {
            inventoryRepository.SaveChanges();
        }

        public IEnumerable<Inventory> SelectList(Expression<Func<Inventory, bool>> predicate)
        {
            return inventoryRepository.Find(predicate);
        }

        //public IEnumerable<Inventory> Any(Expression<Func<Inventory, bool>> predicate)
        //{
        //    return inventoryRepository.Any(predicate);
        //}
       
    }
}

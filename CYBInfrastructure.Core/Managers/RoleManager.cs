using CYBInfracstructure.DataStructure.Entities;
using CYBInfrastructure.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Managers
{
   public class RoleManager:IRoleManager
    {
        private readonly IRoleRepository _rolerepository;
        public RoleManager(IRoleRepository _rolerepository)
        {
            this._rolerepository = _rolerepository;
        }
        public Role Get(int id)
        {

            return _rolerepository.Get(id);
        }
        public IEnumerable<Role> GetAll()
        {
            return _rolerepository.GetAll();
        }
        public void Edit(Role entity)
        {
            _rolerepository.Edit(entity);
            SaveChanges();
        }
        public void SaveChanges()
        {
            _rolerepository.SaveChanges();
        }
    }
}

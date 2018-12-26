using CYBInfracstructure.DataStructure;
using CYBInfracstructure.DataStructure.Entities;
using CYBInfrastructure.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Repository
{
   public class RoleRepository:IRoleRepository
    {
        private readonly CYBInfrastrctureContext context;
        public RoleRepository(CYBInfrastrctureContext context)
        {
            this.context = context;
        }


        public Role Get(int id)
        {
            return context.Set<Role>().Find(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return context.Set<Role>().ToList();
        }
        public void Edit(Role entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

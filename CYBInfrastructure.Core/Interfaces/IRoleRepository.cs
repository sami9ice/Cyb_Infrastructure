using CYBInfracstructure.DataStructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYBInfrastructure.Core.Interfaces
{
    public interface IRoleRepository
    {
        Role Get(int id);
        IEnumerable<Role> GetAll();
        void Edit(Role entity);
        void SaveChanges();

    }
}

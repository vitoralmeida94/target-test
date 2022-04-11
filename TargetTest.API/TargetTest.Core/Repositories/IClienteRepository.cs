using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTest.Core.Entities;

namespace TargetTest.Core.Repositories
{
    public interface IClienteRepository
    {
        Cliente Insert(Cliente cliente);

        Cliente Update(Cliente cliente);

        void Delete(Cliente cliente);

        Cliente GetById(int id);

        List<Cliente> GetAll();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTest.Core.Entities;
using TargetTest.Core.Repositories;
using TargetTest.Infrastructe.Persistence;

namespace TargetTest.Infrastructure.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly TargetDbContext _context;
        public ClienteRepository(TargetDbContext context)
        {
            _context = context;
        }

        public void Delete(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public List<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente Insert(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}

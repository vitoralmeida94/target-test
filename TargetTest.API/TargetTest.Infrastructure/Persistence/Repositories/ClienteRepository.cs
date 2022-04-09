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
            return _context.Clientes.ToList();
        }

        public Cliente GetById(int id)
        {
            return _context.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public Cliente Insert(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public Cliente Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
            return cliente;
        }
    }
}

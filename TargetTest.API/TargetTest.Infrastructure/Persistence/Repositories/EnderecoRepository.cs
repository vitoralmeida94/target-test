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
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly TargetDbContext _context;
        public EnderecoRepository(TargetDbContext context)
        {
            _context = context;
        }
        public void Delete(Endereco endereco)
        {
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
        }

        public Endereco GetByClienteId(int clienteId)
        {
            return _context.Enderecos.FirstOrDefault(x => x.ClientId == clienteId);
        }

        public Endereco Insert(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return endereco;
        }

        public Endereco Update(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);
            _context.SaveChanges();
            return endereco;
        }
    }
}

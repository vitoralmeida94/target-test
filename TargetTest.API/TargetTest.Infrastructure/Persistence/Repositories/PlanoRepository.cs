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
    public class PlanoRepository : IPlanoRepository
    {
        private readonly TargetDbContext _context;
        public PlanoRepository(TargetDbContext context)
        {
            _context = context;
        }
        public void Delete(Plano plano)
        {
            _context.Planos.Remove(plano);
            _context.SaveChanges();
        }

        public List<Plano> GetAll()
        {
            return _context.Planos.ToList();
        }

        public Plano GetById(int id)
        {
            return _context.Planos.FirstOrDefault(x => x.Id == id);
        }

        public Plano Insert(Plano plano)
        {
            _context.Planos.Add(plano);
            _context.SaveChanges();
            return plano;
        }

        public Plano Update(Plano plano)
        {
            _context.Planos.Update(plano);
            _context.SaveChanges();
            return plano;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTest.Application.Services.Interfaces;
using TargetTest.Core.Entities;
using TargetTest.Infrastructe.Persistence;

namespace TargetTest.Application.Services.Implemetations
{
    public class LogService : ILogService
    {
        private readonly TargetDbContext  _context;
        public LogService(TargetDbContext context)
        {
            _context = context;
        }
        public void Registra(Log log)
        {
            _context.Logs.Add(log);
            _context.SaveChanges();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTest.Infrastructe.Persistence;

namespace TargetTest.Tests.Repositories
{
    public static class Startup
    {
        public static TargetDbContext _context;
        public static void Init()
        {
            var dbContextOptions = new DbContextOptionsBuilder<TargetDbContext>().UseInMemoryDatabase(databaseName: "DbTest");
            _context = new TargetDbContext(dbContextOptions.Options);
            _context.Database.EnsureCreated();
        }
    }
}

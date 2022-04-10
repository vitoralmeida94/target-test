using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTest.Core.Entities;

namespace TargetTest.Core.Repositories
{
    public interface IPlanoRepository
    {
        Plano Insert(Plano plano);

        Plano Update(Plano plano);

        void Delete(Plano plano);

        Plano GetById(int id);

        List<Plano> GetAll();
    }
}

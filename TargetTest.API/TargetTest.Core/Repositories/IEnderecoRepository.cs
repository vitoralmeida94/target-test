using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTest.Core.Entities;

namespace TargetTest.Core.Repositories
{
    public interface IEnderecoRepository
    {
        Endereco Insert(Endereco endereco);

        Endereco Update(Endereco endereco);

        void Delete(Endereco endereco);

        Endereco GetByClienteId(int clienteId);

    }
}

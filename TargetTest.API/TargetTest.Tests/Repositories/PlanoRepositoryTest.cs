using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTest.Core.Entities;
using TargetTest.Infrastructure.Persistence.Repositories;
using Xunit;

namespace TargetTest.Tests.Repositories
{
    public class PlanoRepositoryTest
    {
        private PlanoRepository _repository;
        public PlanoRepositoryTest()
        {
            Startup.Init();
            _repository = new PlanoRepository(Startup._context);
        }

        [Theory]
        [InlineData("PlanoTeste","Plano para testar",0.00)]
        [InlineData("Plano VIP Testador", "Plano para testar", 150.00)]
        [InlineData("Plano Test123", "Plano para testar", 1200.00)]
        [InlineData("Plano Beta555", "Plano para testar", 888.00)]
        public void InsertPlanoSuccess(string nome, string descricao, decimal valor)
        {
            var plano = new Plano(nome,descricao,valor);
            var planoResultado = _repository.Insert(plano);
            Assert.NotNull(planoResultado);
            Assert.NotEqual(0, plano.Id);
            Assert.Equal(plano.Descricao, planoResultado.Descricao);
            Assert.Equal(plano.Valor, planoResultado.Valor);
            Assert.Equal(plano.Nome, planoResultado.Nome);
        }
      

    }
}

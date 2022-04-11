using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTest.Application.ExternalServices.Implemetations;
using Xunit;

namespace TargetTest.Tests.ExternalTest
{
    public class IbgeTest
    {
        private IbgeService _service;
        public IbgeTest()
        {
            _service = new IbgeService();
        }

        [Fact]
        public async Task GetEstados()
        {
            var lista = await _service.ListaEstados();
            Assert.NotEmpty(lista);
        }

        [Fact]
        public async Task GetMunicipios()
        {
            var lista = await _service.ListaMunicipios("RJ");
            Assert.NotEmpty(lista);
        }
    }
}

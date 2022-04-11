using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTest.Application.InputModels;
using TargetTest.Application.Validators;
using Xunit;

namespace TargetTest.Tests.Validators
{
    public class CriacaoClienteInputModelValidatorTest
    {
        private CriacaoClienteInputModelValidator _validator;
        public CriacaoClienteInputModelValidatorTest()
        {
            _validator = new CriacaoClienteInputModelValidator();
        }
        [Fact]
        public void CriacaoClienteInputModelValidator_Fail()
        {
            var clienteInputModel = new CriacaoClienteInputModel();
            var result = _validator.Validate(clienteInputModel);
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public void CriacaoClienteInputModelValidator_Fail_WithValidCPF()
        {
            var clienteInputModel = new CriacaoClienteInputModel();
            clienteInputModel.CPF = "14866452757";
            var result = _validator.Validate(clienteInputModel);
            var cpfError = result.Errors.Where(x => x.ErrorMessage.Contains("CPF")).ToList();
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
            Assert.Empty(cpfError);
        }
        [Fact]
        public void CriacaoClienteInputModelValidator_Fail_WithValidCEP()
        {
            var clienteInputModel = new CriacaoClienteInputModel();
            clienteInputModel.CEP = "20735280";
            var result = _validator.Validate(clienteInputModel);
            var cepError = result.Errors.Where(x => x.ErrorMessage.Contains("CEP")).ToList();
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
            Assert.Empty(cepError);
        }

        [Fact]
        public void CriacaoClienteInputModelValidator_Success()
        {
            var clienteInputModel = new CriacaoClienteInputModel
            {
                NomeCompleto = "Vitor de Almeida",
                CEP = "20735280",
                CPF = "14866452757",
                Bairro = "Méier",
                Cidade = "Rio de Janeiro",
                Complemento = "fundos",
                Logradouro = "Rua Coronel Cota",
                DataNascimento = new DateTime(1994,7,4),
                Renda = 3000,
                UF = "RJ"
            };
            var result = _validator.Validate(clienteInputModel);
            var cepError = result.Errors.Where(x => x.ErrorMessage.Contains("CEP")).ToList();
            var cpfError = result.Errors.Where(x => x.ErrorMessage.Contains("CPF")).ToList();
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
            Assert.Empty(cepError);
            Assert.Empty(cpfError);
        }
    }
}

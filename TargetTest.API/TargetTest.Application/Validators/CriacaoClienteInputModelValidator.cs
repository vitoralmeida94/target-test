using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TargetTest.Application.InputModels;

namespace TargetTest.Application.Validators
{
    public class CriacaoClienteInputModelValidator : AbstractValidator<CriacaoClienteInputModel>
    {
        public CriacaoClienteInputModelValidator()
        {
            RuleFor(p => p.NomeCompleto)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo Nome Completo é obrigatório.");

            RuleFor(p => p.NomeCompleto)
                .MaximumLength(80)
                .WithMessage("O campo Nome Completo tem o tamanho máximo de 80 caracteres.");

            RuleFor(p => p.DataNascimento)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo data nascimento é obrigatório.");

            RuleFor(p => p.Logradouro)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo logradouro é obrigatório.");

            RuleFor(p => p.Logradouro)
                .MaximumLength(100)
                .WithMessage("Logradouro tem tamanho máximo de 100 caracteres.");

            RuleFor(p => p.Bairro)
               .NotNull()
               .NotEmpty()
               .WithMessage("O campo bairro é obrigatório.");

            RuleFor(p => p.Bairro)
               .MaximumLength(40)
               .WithMessage("Bairro tem tamanho máximo de 40 caracteres.");

            RuleFor(p => p.Cidade)
               .NotNull()
               .NotEmpty()
               .WithMessage("O campo cidade é obrigatório");

            RuleFor(p => p.Cidade)
               .MaximumLength(50)
               .WithMessage("Cidade tem tamanho máximo de 50 caracteres.");

            RuleFor(p => p.Complemento)
               .NotNull()
               .NotEmpty()
               .WithMessage("O campo complemento é obrigatório.");

            RuleFor(p => p.Complemento)
              .MaximumLength(20)
              .WithMessage("Cidade tem tamanho máximo de 50 caracteres.");

            RuleFor(p => p.UF)
               .NotNull()
               .NotEmpty()
               .WithMessage("O campo UF é obrigatório.");

            RuleFor(p => p.UF)
              .MinimumLength(2)
              .MaximumLength(2)
              .WithMessage("UF tem tamanho máximo e mínimo de 2 caracteres.");

            RuleFor(p => p.Renda)
                .NotNull()
                .NotEmpty()
                .GreaterThan(-0.1m)
                .WithMessage("Renda precisa ser preenchida e sendo um número igual ou superior a zero.");
            
            RuleFor(p => p.CPF)
              .NotNull()
              .NotEmpty()
              .MinimumLength(11)
              .MaximumLength(11)
              .Must(ValidaCPF)
              .WithMessage("CPF tem tamanho máximo e mínimo de 11 caracteres, sendo somentes números.");

            RuleFor(p => p.CEP)
              .NotNull()
              .NotEmpty()
              .MinimumLength(8)
              .MaximumLength(8)
              .Must(ValidaCEP)
              .WithMessage("CEP tem tamanho máximo e mínimo de 8 caracteres, sendo somentes números.");
        }

        bool ValidaCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                return false;
            }
            var regex = new Regex(@"[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]");

            return regex.IsMatch(cpf);
        }

        bool ValidaCEP(string cep)
        {
            if (string.IsNullOrEmpty(cep))
            {
                return false;
            }
            var regex = new Regex(@"[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]");

            return regex.IsMatch(cep);
        }
    }
}

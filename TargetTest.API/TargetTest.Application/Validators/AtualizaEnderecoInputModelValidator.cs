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
    public class AtualizaEnderecoInputModelValidator : AbstractValidator<AtualizaEnderecoInputModel>
    {
        public AtualizaEnderecoInputModelValidator()
        {
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

            RuleFor(p => p.Uf)
               .NotNull()
               .NotEmpty()
               .WithMessage("O campo UF é obrigatório.");

            RuleFor(p => p.Uf)
              .MinimumLength(2)
              .MaximumLength(2)
              .WithMessage("UF tem tamanho máximo e mínimo de 2 caracteres");
            RuleFor(p => p.CEP)
             .NotNull()
             .NotEmpty()
             .Must(ValidaCEP)
             .WithMessage("CEP tem tamanho máximo e mínimo de 8 caracteres, sendo somentes números.");
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

using FluentValidation;
using Lartech.Domain.Interfaces;

namespace Lartech.Domain.Entidades
{
    public class Pessoa : Entity, IAggregateRoot
    {

        public Pessoa(string nome, string cpf, DateTime datanascimento, bool ativo)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = datanascimento;
            Ativo = ativo;
        }

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public bool Ativo { get; set; }

        public override bool Validar()
        {
            ValidationResult = new PessoaValidation().Validate(this);
            foreach (var erro in ValidationResult.Errors)
            {
                AdicionarErros(erro.ErrorMessage);
            }
            return ValidationResult.IsValid;
        }

        public class PessoaValidation : AbstractValidator<Pessoa>
        {
            public PessoaValidation()
            {
                RuleFor(p => p.Id)
                     .NotEqual(Guid.Empty)
                     .WithMessage("Id não pode ser vazio.");

                RuleFor(p => p.Nome)
                    .NotEmpty()
                    .WithMessage("O nome deve ser informado.");

                RuleFor(p => p.Nome)
                    .MinimumLength(5)
                    .WithMessage("O nome deve ter no mínimo 5 caracteres.");

                RuleFor(p => p.Nome)
                    .MaximumLength(100)
                    .WithMessage("O nome deve ter no máximo 100 caracteres.");

                RuleFor(p => p.DataNascimento)
                     .NotEqual(null)
                     .WithMessage("Data de nascimento deve ser informada.");

                RuleFor(p => p.CPF)
                    .Must(ValidarCPF)
                    .WithMessage("CPF inválido.");

            }

            protected static bool ValidarCPF(string cpf)
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;
                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");
                if (cpf.Length != 11)
                    return false;
                tempCpf = cpf.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return cpf.EndsWith(digito);
            }
        }
    }
}

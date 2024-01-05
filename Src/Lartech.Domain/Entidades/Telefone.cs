using FluentValidation;

namespace Lartech.Domain.Entidades
{

    public enum TipoTelefone
    {
        Celular,
        Residencial,
        Comercial
    }

    public class Telefone : Entity
    {

        public Telefone(Guid pessoaId, TipoTelefone tipo, string numero)
        {
            PessoaId = pessoaId;
            Tipo = tipo;
            Numero = numero;
        }


        public Guid PessoaId { get; private set; }
        public TipoTelefone Tipo {  get; private set; }
        public string Numero { get; private set; }


        // EF
        public Pessoa Pessoa { get; set; }

        public override bool Validar()
        {
            ValidationResult = new TelefoneValidation().Validate(this);
            foreach (var erro in ValidationResult.Errors)
            {
                AdicionarErros(erro.ErrorMessage);
            }
            return ValidationResult.IsValid;
        }

        public class TelefoneValidation : AbstractValidator<Telefone>
        {
            public TelefoneValidation()
            {
                RuleFor(t => t.Id)
                     .NotEqual(Guid.Empty)
                     .WithMessage("Id não pode ser vazio.");

                RuleFor(t => t.Tipo)
                    .NotEmpty()
                    .WithMessage("O tipo de telefone deve ser informado.");

                RuleFor(t => t.Numero)
                    .MinimumLength(11)
                    .WithMessage("Informe o telefone com o DDD.");

                RuleFor(t => t.Numero)
                    .MaximumLength(11)
                    .WithMessage("O telefone deve ter 11 digitos.");
            }
        }

    }
}

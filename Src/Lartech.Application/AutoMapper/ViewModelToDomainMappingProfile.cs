using AutoMapper;
using Lartech.Application.Models;
using Lartech.Domain.Entidades;

namespace Lartech.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PessoaModel, Pessoa>()
                .ConstructUsing(p => new Pessoa(p.Nome, p.CPF, p.DataNascimento, p.Ativo));

            CreateMap<TelefoneModel, Telefone>()
                .ConstructUsing(t => new Telefone(t.PessoaId, t.Tipo, t.Numero));


        }
    }
}

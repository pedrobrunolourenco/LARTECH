using AutoMapper;
using Lartech.Application.Interfaces;
using Lartech.Application.Models;
using Lartech.Domain.Entidades;
using Lartech.Domain.Interfaces.Service;

namespace Lartech.Application.Services
{
    public class AppPessoa : IAppPessoa
    {

        private readonly IMapper _mapper;
        private readonly IServicePessoa _servicePessoa;

        public AppPessoa(IMapper mapper,
                         IServicePessoa servicePessoa)
        {
            _mapper = mapper;
            _servicePessoa = servicePessoa;
        }

        public IEnumerable<PessoaModel> ObterTodas()
        {
            return _mapper.Map<IEnumerable<PessoaModel>>(_servicePessoa.ObterTodas());
        }

        public IEnumerable<PessoaModel> ObterAtivos()
        {
            return _mapper.Map<IEnumerable<PessoaModel>>(_servicePessoa.ObterAtivos());
        }

        public IEnumerable<PessoaModel> ObterInativos()
        {
            return _mapper.Map<IEnumerable<PessoaModel>>(_servicePessoa.ObterInativos());
        }
        public PessoaModel? ObterPorId(Guid id)
        {
            return _mapper.Map<PessoaModel>(_servicePessoa.ObterPorId(id));
        }

        public PessoaModel? ObterPorCpf(string cpf)
        {
            return _mapper.Map<PessoaModel>(_servicePessoa.ObterPorCpf(cpf));
        }

        public IEnumerable<PessoaModel> ObterPorParteDoNome(string nome)
        {
            return _mapper.Map<IEnumerable<PessoaModel>>(_servicePessoa.ObterPorParteDoNome(nome));
        }


        public PessoaModel IncluirPessoa(PessoaModel pessoa)
        {
            return _mapper.Map<PessoaModel>(_servicePessoa.IncluirPessoa(_mapper.Map<Pessoa>(pessoa)));
        }
        public PessoaModel AlterarPessoa(PessoaModel pessoa)
        {
            return _mapper.Map<PessoaModel>(_servicePessoa.AlterarPessoa(_mapper.Map<Pessoa>(pessoa)));
        }

        public void ExcluirPessoa(Guid id)
        {
            _servicePessoa.ExcluirPessoa(id);
        }


        public TelefoneModel AdicionarTelefone(TelefoneModel fone)
        {
            return _mapper.Map<TelefoneModel>(_servicePessoa.AdicionarTelefone(_mapper.Map<Telefone>(fone)));
        }

        public TelefoneModel AlterarTelefone(TelefoneModel fone)
        {
            return _mapper.Map<TelefoneModel>(_servicePessoa.AlterarTelefone(_mapper.Map<Telefone>(fone)));
        }
        public void ExcluirTelefone(Guid idtelefone)
        {
            _servicePessoa.ExcluirTelefone(idtelefone);
        }

        public PessoaModel Ativar(PessoaModel pessoa)
        {
            return _mapper.Map<PessoaModel>(_servicePessoa.Ativar(_mapper.Map<Pessoa>(pessoa)));
        }

        public PessoaModel Inativar(PessoaModel pessoa)
        {
            return _mapper.Map<PessoaModel>(_servicePessoa.Inativar(_mapper.Map<Pessoa>(pessoa)));
        }




    }
}

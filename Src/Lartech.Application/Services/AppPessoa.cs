﻿using AutoMapper;
using Lartech.Application.Interfaces;
using Lartech.Application.Models;
using Lartech.Domain.DTOS;
using Lartech.Domain.Entidades;
using Lartech.Domain.Interfaces.Service;
using static System.Net.Mime.MediaTypeNames;

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

        public IEnumerable<PessoaViewModel> ObterTodos()
        {
            return _servicePessoa.ObterTodos();
        }

        public IEnumerable<PessoaViewModel> ObterAtivos()
        {
            return _servicePessoa.ObterAtivos();
        }

        public IEnumerable<PessoaViewModel> ObterInativos()
        {
            return _servicePessoa.ObterInativos();
        }
        public PessoaViewModel? ObterPorId(Guid id)
        {
            return _servicePessoa.ObterPorId(id);
        }

        public PessoaViewModel? ObterPorCpf(string cpf)
        {
            return _servicePessoa.ObterPorCpf(cpf);
        }

        public IEnumerable<PessoaViewModel> ObterPorParteDoNome(string nome)
        {
            return _servicePessoa.ObterPorParteDoNome(nome);
        }


        public PessoaModel IncluirPessoa(PessoaModel pessoa)
        {
            var xpessoa = _mapper.Map<Pessoa>(pessoa);
            foreach (var fone in pessoa.ListaTelefone)
            {
                xpessoa.AdicionarTelefoneNaLista(_mapper.Map<Telefone>(fone));
            }
            return _mapper.Map<PessoaModel>(_servicePessoa.IncluirPessoa(xpessoa));
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

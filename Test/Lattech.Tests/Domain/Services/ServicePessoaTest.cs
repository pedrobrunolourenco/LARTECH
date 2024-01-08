using Lartech.Domain.DTOS;
using Lartech.Domain.Entidades;
using Lartech.Domain.Interfaces.Repository;
using Lartech.Domain.Interfaces.Service;
using Lartech.Domain.Services;
using Moq;

namespace Lattech.Tests.Domain.Services
{
    public class ServicePessoaTest
    {
        public Pessoa pessoaOk { get; set; }
        public Pessoa pessoaDados { get; set; }
        public Telefone telefone { get; set; }
        public PessoaViewModel pessoaViewModel { get; set; }


        public ServicePessoaTest()
        {
            pessoaOk = new Pessoa("Teste Pessoa Ok",
                            "38651203187",
                            DateTime.Today.AddYears(-10),
                            true);
            telefone = new Telefone(pessoaOk.Id, 0, "21967628309");
            pessoaOk.ListaTelefones.Add(telefone);


            pessoaDados = new Pessoa("Pessoa Pura",
                                     "32486002090",
                                      DateTime.Today.AddYears(-20),
                                      true);


        }


        [Fact(DisplayName = "Incluir Pessoa")]
        public void IncluirPessoa()
        {
            // arrange
            var repositoryPessoa = new Mock<IRepositoryPessoa> ();
            var repositoryTelefone = new Mock<IRepositoryTelefone>();
            // Act
            var pessoaService = new ServicePessoa(repositoryPessoa.Object,
                                                  repositoryTelefone.Object);
            // assert
            Assert.True(!pessoaService.IncluirPessoa(pessoaOk).ListaErros.Any());
        }


        [Fact(DisplayName = "Alterar Pessoa")]
        public void AlterarPessoa()
        {
            // arrange
            var repositoryPessoa = new Mock<IRepositoryPessoa>();
            var repositoryTelefone = new Mock<IRepositoryTelefone>();
            // Act
            var pessoaService = new ServicePessoa(repositoryPessoa.Object,
                                                  repositoryTelefone.Object);
            // assert
            Assert.True(!pessoaService.AlterarPessoa(pessoaDados, pessoaDados.Id).ListaErros.Any());
        }

        [Fact(DisplayName = "Ativar Pessoa")]
        public void AtivarPessoa()
        {
            // arrange
            var repositoryPessoa = new Mock<IRepositoryPessoa>();
            var repositoryTelefone = new Mock<IRepositoryTelefone>();

            // Act
            var pessoaService = new ServicePessoa(repositoryPessoa.Object,
                                                  repositoryTelefone.Object);

            repositoryPessoa.Setup(x => x.BuscarId(It.IsAny<Guid>())).Returns(pessoaOk);

            // assert
            Assert.True(pessoaService.AtivarPessoa(pessoaDados.Id).Ativo == true);
        }

        [Fact(DisplayName = "Inativar Pessoa")]
        public void InativarPessoa()
        {
            // arrange
            var repositoryPessoa = new Mock<IRepositoryPessoa>();
            var repositoryTelefone = new Mock<IRepositoryTelefone>();
            // Act
            var pessoaService = new ServicePessoa(repositoryPessoa.Object,
                                                  repositoryTelefone.Object);

            repositoryPessoa.Setup(x => x.BuscarId(It.IsAny<Guid>())).Returns(pessoaOk);
            // assert
            Assert.True(pessoaService.InativarPessoa(pessoaDados.Id).Ativo == false);
        }


    }
}

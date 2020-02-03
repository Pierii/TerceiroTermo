using Microsoft.EntityFrameworkCore;
using Senai.CodeTur.Dominio.Entidades;
using Senai.CodeTur.Dominio.Interfaces.Repositorios;
using Senai.CodeTur.Infra.Data.Contextos;
using Senai.CodeTur.Infra.Data.Repositorios;
using System;
using Xunit;

namespace Senai.CodeTur.Teste.XUnit.Repositorios
{
    public class TestePacote
    {


        [Theory]
        [InlineData(1)]
        public void TestePacoteBuscarPorIdNaoExiste(int id)
        {
            var options = new DbContextOptionsBuilder<CodeTurContext>()
                .UseInMemoryDatabase(databaseName: "BuscaPorIdNaoExiste")
                .Options;

            // Use a clean instance of the context to run the test
            using (var context = new CodeTurContext(options))
            {
                var repo = new PacoteRepositorio(context);
                var result = repo.BuscarPorId(1);
                Assert.Null(result);
            }
        }

        [Fact]
        public void TestePacoteCadastrar()
        {

            var options = new DbContextOptionsBuilder<CodeTurContext>()
                .UseInMemoryDatabase(databaseName: "PacoteCadastrar")
                .Options;

            PacoteDominio pacote = new PacoteDominio()
            {
                Titulo = "Pacote 5 Empresas Canada",
                Imagem = "https://www.albait-alcanadi.com/wp-content/uploads/2016/05/canada-business-immigration-programs-al-bait-al-canadi-for-immigration-services-600x330.jpg",
                Pais = "Canada",
                Ativo = true,
                DataInicio = DateTime.Now.AddDays(-20),
                DataFim = DateTime.Now.AddDays(-13),
                Descricao = "Conheça diversas empresas no Canada"
            };

            // Use a clean instance of the context to run the test
            using (var context = new CodeTurContext(options))
            {
                var service = new PacoteRepositorio(context);
                var result = service.Cadastrar(pacote);
                Assert.NotNull(result);
                Assert.Equal("Pacote 5 Empresas Canada", result.Titulo);
            }

        }

        [Fact]
        public void TestePacoteBuscarPorIdExiste()
        {

            var options = new DbContextOptionsBuilder<CodeTurContext>()
                .UseInMemoryDatabase(databaseName: "PacoteCadastrar")
                .Options;

            PacoteDominio pacote = new PacoteDominio()
            {
                Titulo = "Pacote 5 Empresas Canada",
                Imagem = "https://www.albait-alcanadi.com/wp-content/uploads/2016/05/canada-business-immigration-programs-al-bait-al-canadi-for-immigration-services-600x330.jpg",
                Pais = "Canada",
                Ativo = true,
                DataInicio = DateTime.Now.AddDays(-20),
                DataFim = DateTime.Now.AddDays(-13),
                Descricao = "Conheça diversas empresas no Canada"
            };

            // Use a clean instance of the context to run the test
            using (var context = new CodeTurContext(options))
            {
                var service = new PacoteRepositorio(context);

                service.Cadastrar(pacote);

                var result = service.BuscarPorId(1);
                Assert.NotNull(result);
                Assert.Equal(1, result.Id);
            }

        }

    }
}

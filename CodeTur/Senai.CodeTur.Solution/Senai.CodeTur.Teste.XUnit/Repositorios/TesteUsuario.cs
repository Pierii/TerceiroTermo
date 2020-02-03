using Microsoft.EntityFrameworkCore;
using Senai.CodeTur.Dominio.Entidades;
using Senai.CodeTur.Dominio.Interfaces.Repositorios;
using Senai.CodeTur.Infra.Data.Contextos;
using Senai.CodeTur.Infra.Data.Repositorios;
using Xunit;

namespace Senai.CodeTur.Teste.XUnit.Repositorios
{
    public class TesteUsuario
    {
       
        [Fact]
        public void VerificaSeUsuarioEInvalido()
        {
            var options = new DbContextOptionsBuilder<CodeTurContext>()
               .UseInMemoryDatabase(databaseName: "UsuarioEInvalido")
               .Options;

            // Use a clean instance of the context to run the test
            using (var context = new CodeTurContext(options))
            {
                var repo = new UsuarioRepositorio(context);
                var validacao = repo.EfetuarLogin("admin@gmail.co", "12345");

                Assert.Null(validacao);
            }
        }

        [Fact]
        public void VerificaSeUsuarioEValido()
        {
            var options = new DbContextOptionsBuilder<CodeTurContext>()
               .UseInMemoryDatabase(databaseName: "UsuarioEValido")
               .Options;

            // Use a clean instance of the context to run the test
            using (var context = new CodeTurContext(options))
            {
                var repo = new UsuarioRepositorio(context);
                var validacao = repo.EfetuarLogin("admin@codetur.com", "12345");

                Assert.Null(validacao);
            }
        }

        [Fact]
        public void VerificaSeUsuarioEValidoEInfoCorretas()
        {
            var options = new DbContextOptionsBuilder<CodeTurContext>()
               .UseInMemoryDatabase(databaseName: "UsuarioEValidoEInfoCorretas")
               .Options;

            UsuarioDominio usuario = new UsuarioDominio()
            {
                Email = "admin@codetur.com",
                Senha = "Codetur@132",
                Tipo = "Administrador"
            };

            // Use a clean instance of the context to run the test
            using (var context = new CodeTurContext(options))
            {
                var repo = new UsuarioRepositorio(context);

                context.Usuarios.Add(usuario);
                context.SaveChanges();

                UsuarioDominio usuarioRetorno = repo.EfetuarLogin(usuario.Email, usuario.Senha);

                Assert.Equal(usuarioRetorno.Email, usuario.Email);
                Assert.Equal(usuarioRetorno.Senha, usuario.Senha);
            }
        }
    }
}

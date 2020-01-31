using Senai.CodeTur.Dominio.Entidades;

namespace Senai.CodeTur.Dominio.Interfaces
{
    namespace Senai.CodeTur.Dominio.Interfaces.Repositorios
    {
        public interface IUsuario
        {
            UsuarioDominio EfetuarLogin(string email, string senha);
        }
    }
}

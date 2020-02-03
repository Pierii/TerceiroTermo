using Senai.CodeTur.Dominio.Entidades;
using Senai.CodeTur.Dominio.Interfaces.Repositorios;
using Senai.CodeTur.Infra.Data.Contextos;
using System.Linq;

namespace Senai.CodeTur.Infra.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private CodeTurContext _context;

        public UsuarioRepositorio(CodeTurContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Verifica se um usuário existe no banco atraves do seu e-mail e senha
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do Usuário</param>
        /// <returns>Objeto UsuarioDominio</returns>
        public UsuarioDominio EfetuarLogin(string email, string senha)
        {
            try
            {
                //Busca um usuário a partir do seu e-mail e senha
                return _context.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}

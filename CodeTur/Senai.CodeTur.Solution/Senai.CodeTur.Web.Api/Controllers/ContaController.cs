using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.CodeTur.Dominio.Interfaces.Repositorios;
using Senai.CodeTur.Infra.Data.Repositorios;
using Senai.CodeTur.Servico.ViewModels.Conta;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Senai.CodeTur.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        //Declara uma váriavel do tipo IUsuarioRepositorio
        private IUsuarioRepositorio _usuarioRepositorio;

        //Utiliza injeção de dependência definida no startup
        public ContaController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        /// <summary>
        /// Efetua login na api 
        /// </summary>
        /// <param name="usuario">Email e senha do usuário</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/conta
        ///     {
        ///        "email": "adm@adm.com",
        ///        "senha": "123"
        ///     }
        ///
        /// </remarks>
        /// <returns>Retorna um token</returns>
        /// <response code="400">Ocorreu um erro</response>
        /// <response code="404">Usuário não encontrado</response>   
        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                var usuarioRetorno = _usuarioRepositorio.EfetuarLogin(usuario.Email, usuario.Senha);

                if (usuarioRetorno == null)
                {
                    return NotFound(new { mensagem = "Email ou senha inválido" });
                }

                //Define os dados que serão fornecidos no token - PayLoad
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioRetorno.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioRetorno.Id.ToString())
                };

                // Chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("codetur-chave-autenticacao"));

                //Credenciais do Token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Gera o token
                var token = new JwtSecurityToken(
                    issuer: "CodeTur.WebApi",
                    audience: "CodeTur.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                //Retorna Ok com o Token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = ex.Message });
            }
        }
    }
}
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.CodeTur.Dominio.Entidades;
using Senai.CodeTur.Dominio.Interfaces.Repositorios;
using Senai.CodeTur.Servico.ViewModels.Pacote;

namespace Senai.CodeTur.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacoteController : ControllerBase
    {

        //Declara uma váriavel do tipo IPacoteRepositorio
        private IPacoteRepositorio _pacoteRepositorio { get; set; }

        //Utiliza injeção de dependência definida no startup
        public PacoteController(IPacoteRepositorio pacoteRepositorio)
        {
            _pacoteRepositorio = pacoteRepositorio;
        }

        /// <summary>
        /// Cadastra um novo pacote
        /// </summary>
        /// <param name="pacote">Pacote a ser cadastrado</param>
        /// <returns>Retorna o pacote Cadastrado</returns>
        [HttpPost]
        [Authorize]
        public IActionResult Post(CadastrarPacoteViewModel pacote)
        {
            try
            {
                PacoteDominio pacoteNovo = new PacoteDominio()
                {
                    Titulo = pacote.Titulo,
                    Descricao = pacote.Descricao,
                    Imagem = pacote.Imagem,
                    DataInicio = pacote.DataInicio,
                    DataFim = pacote.DataFim,
                    Ativo = pacote.Ativo,
                    Pais = pacote.Pais
                };

                var pacoteRetorno = _pacoteRepositorio.Cadastrar(pacoteNovo);

                return Ok(pacoteRetorno);
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Lista os Pacotes conforme o parametro que for passado
        /// </summary>
        /// <param name="todos">Lista todos os pacotes</param>
        /// <returns>Retorna um List<PacoteDominio></returns>
        [HttpGet]
        [Route("listar")]
        [Authorize]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_pacoteRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Lista os Pacotes conforme o parametro que for passado
        /// </summary>
        /// <param name="todos">Lista todos os pacotes</param>
        /// <returns>Retorna um List<PacoteDominio></returns>
        [HttpGet]
        [Route("listarativos")]
        public IActionResult ListarAtivos()
        {
            try
            {
                return Ok(_pacoteRepositorio.Listar(true));
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Busca um pacote pelo id
        /// </summary>
        /// <param name="id">ide pacote</param>
        /// <returns>Retorna um objeto do tipo pacote</returns>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var pacote = _pacoteRepositorio.BuscarPorId(id);

                if (pacote == null)
                    return NotFound(new { mensagem = "Pacote não encontrado" });

                return Ok(pacote);
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = ex.Message });
            }
        }
    }
}
using Senai.CodeTur.Dominio.Entidades;
using Senai.CodeTur.Dominio.Interfaces.Repositorios;
using Senai.CodeTur.Infra.Data.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai.CodeTur.Infra.Data.Repositorios
{
    public class PacoteRepositorio : IPacoteRepositorio, IDisposable
    {

        //Declara uma váriavel do tipo Context
        private CodeTurContext _context;

        //Utiliza injeção de dependência.
        public PacoteRepositorio(CodeTurContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca um pacote pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PacoteDominio BuscarPorId(int id)
        {
            try
            {
                // busca um pacote pelo id
                return _context.Pacotes.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo pacote
        /// </summary>
        /// <param name="pacote">Dados do pacote</param>
        /// <returns>Retorna pacote cadastrado</returns>
        public PacoteDominio Cadastrar(PacoteDominio pacote)
        {
            try
            {
                //Adiciona um pacote ao dbset
                _context.Pacotes.Add(pacote);
                //salva o pacote
                _context.SaveChanges();

                //retorna o pacote cadastrado
                return pacote;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista os pacote cadastrados
        /// </summary>
        /// <param name="todos">Se não receber parametro retorna todos os pacotes, se receber true retorna somente pacotes ativo, se receber false retorna os pacotes inativoss</param>
        /// <returns></returns>
        public List<PacoteDominio> Listar(bool? todos = null)
        {
            try
            {
                //If não receber parametro retorna todos os pacotes
                if (todos == null)
                {
                    return _context.Pacotes.ToList();
                }
                //retorna somente pacotes ativos
                else if (todos == true)
                {
                    return _context.Pacotes.Where(x => x.Ativo == true).ToList();
                }
                //retorna os pacotes inativos
                else
                {
                    return _context.Pacotes.Where(x => x.Ativo == false).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

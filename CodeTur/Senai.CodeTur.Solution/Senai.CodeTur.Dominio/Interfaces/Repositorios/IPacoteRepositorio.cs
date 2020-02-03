using Senai.CodeTur.Dominio.Entidades;
using System.Collections.Generic;

namespace Senai.CodeTur.Dominio.Interfaces.Repositorios
{
    public interface IPacoteRepositorio
    {
        List<PacoteDominio> Listar(bool? todos = null);

        PacoteDominio BuscarPorId(int id);

        PacoteDominio Cadastrar(PacoteDominio pacote);
    }
}

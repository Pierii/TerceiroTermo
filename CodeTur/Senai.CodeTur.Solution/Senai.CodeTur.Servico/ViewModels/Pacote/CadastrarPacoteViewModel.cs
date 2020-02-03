using System;
using System.ComponentModel.DataAnnotations;

namespace Senai.CodeTur.Servico.ViewModels.Pacote
{
    public class CadastrarPacoteViewModel
    {
        [Required(ErrorMessage = "Informe o título do pacote")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Informe a descricao do pacote")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a url da imagem do pacote")]
        public string Imagem { get; set; }

        [Required(ErrorMessage = "Informe a Data de Início")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Informe a Data Final")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "Informe o País")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Informe se o pacote é ativo")]
        public bool Ativo { get; set; }
    }
}

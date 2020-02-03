using System.ComponentModel.DataAnnotations;

namespace Senai.CodeTur.Servico.ViewModels.Conta
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "O email deve ter no mínimo 4 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(20,ErrorMessage = "Informe uma senha com mínimo de 8 e máximo 20 caracteres", MinimumLength = 8)]
        public string Senha { get; set; }
    }
}

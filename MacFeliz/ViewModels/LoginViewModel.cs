using System.ComponentModel.DataAnnotations;

namespace MacFeliz.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Informe o nome")]
        [Display(Name ="Nome do Usuário")]
        public string UserName  { get; set; }

        [Required(ErrorMessage ="Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name ="Senha")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}

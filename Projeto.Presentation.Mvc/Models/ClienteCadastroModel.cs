using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Mvc.Models
{
    public class ClienteCadastroModel
    {
        [Required(ErrorMessage ="Campo Obrigatório.")]
        [MaxLength(150, ErrorMessage = "No Máximo {1} caractéres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [EmailAddress(ErrorMessage ="Informe um Email Valido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [MaxLength(150, ErrorMessage = "No Máximo {1} caractéres.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [MinLength(6, ErrorMessage = "No minimo {1} caractéres.")]
        [MaxLength(150, ErrorMessage = "No Máximo {1} caractéres.")]
        [RegularExpression("^(?=.*[A-z])(?=.*[0-9])(?=.*[!@#$%^&*]).*$", ErrorMessage ="Senha deve Conter no Minimo 1 caracter especial.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Compare(nameof(Senha), ErrorMessage = "Senhas são diferentes.")]
        public string ConfirmarSenha { get; set; }
    }
}

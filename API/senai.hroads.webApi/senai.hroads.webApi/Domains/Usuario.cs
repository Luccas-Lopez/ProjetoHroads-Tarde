using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Usuario
    {
        public short IdUsuario { get; set; }
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatorio!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatorio!")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "A senha deve ter entre 3 a 10 caracteres!")]
        public string Senha { get; set; }
        public short? IdTipoUsuario { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}

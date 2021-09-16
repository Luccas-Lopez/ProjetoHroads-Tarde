using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Personagem
    {
        public string NomePersonagem { get; set; }
        public byte IdPersonagem { get; set; }
        public byte? IdClasse { get; set; }
        public int? CapacidadeVida { get; set; }
        public int? CapacidadeMana { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataCriacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}

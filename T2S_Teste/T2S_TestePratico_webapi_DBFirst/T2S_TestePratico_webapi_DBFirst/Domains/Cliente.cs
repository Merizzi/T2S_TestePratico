using System;
using System.Collections.Generic;

#nullable disable

namespace T2S_TestePratico_webapi_DBFirst.Domains
{
    public partial class Cliente
    {
        public Cliente()
        {
            Conteiners = new HashSet<Conteiner>();
            Movimentacaos = new HashSet<Movimentacao>();
        }

        public int Idcliente { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Conteiner> Conteiners { get; set; }
        public virtual ICollection<Movimentacao> Movimentacaos { get; set; }
    }
}

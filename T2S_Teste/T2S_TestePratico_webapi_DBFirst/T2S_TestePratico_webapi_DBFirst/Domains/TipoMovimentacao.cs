using System;
using System.Collections.Generic;

#nullable disable

namespace T2S_TestePratico_webapi_DBFirst.Domains
{
    public partial class TipoMovimentacao
    {
        public TipoMovimentacao()
        {
            Movimentacaos = new HashSet<Movimentacao>();
        }

        public int IdtipoMovimentacao { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Movimentacao> Movimentacaos { get; set; }
    }
}

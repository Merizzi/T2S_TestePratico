using System;
using System.Collections.Generic;

#nullable disable

namespace T2S_TestePratico_webapi_DBFirst.Domains
{
    public partial class Movimentacao
    {
        public int Idmovimentacao { get; set; }
        public DateTime? DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public int? IdCliente { get; set; }
        public int? IdTipoMovimentacao { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual TipoMovimentacao IdTipoMovimentacaoNavigation { get; set; }
    }
}

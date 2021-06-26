using System;
using System.Collections.Generic;

#nullable disable

namespace T2S_TestePratico_webapi_DBFirst.Domains
{
    public partial class Conteiner
    {
        public int Idconteiner { get; set; }
        public int? Tipo { get; set; }
        public string StatusConteiner { get; set; }
        public string Categoria { get; set; }
        public string NumeroConteiner { get; set; }
        public int? IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
    }
}

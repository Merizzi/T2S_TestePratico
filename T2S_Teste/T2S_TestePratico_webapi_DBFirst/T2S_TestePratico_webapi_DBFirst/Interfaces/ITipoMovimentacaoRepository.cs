using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2S_TestePratico_webapi_DBFirst.Domains;

namespace T2S_TestePratico_webapi_DBFirst.Interfaces
{
    interface ITipoMovimentacaoRepository
    {
        List<TipoMovimentacao> Listar();

        TipoMovimentacao BuscarPorId(int id);

        void Cadastrar(TipoMovimentacao novoTipoMovimentacao);

        void Atualizar(int id, TipoMovimentacao tipomovimentacaoAtualizado);

        void Deletar(int idDeletar);
    }
}

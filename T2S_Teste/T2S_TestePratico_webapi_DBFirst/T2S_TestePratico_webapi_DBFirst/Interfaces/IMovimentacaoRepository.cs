using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2S_TestePratico_webapi_DBFirst.Domains;

namespace T2S_TestePratico_webapi_DBFirst.Interfaces
{
    interface IMovimentacaoRepository
    {
        List<Movimentacao> Listar();

        Movimentacao BuscarPorId(int id);

        void Cadastrar(Movimentacao novoMovimentacao);

        void Atualizar(int id, Movimentacao movimentacaoAtualizado);

        void Deletar(int idDeletar);

        public List<Movimentacao> BuscarIdCliente(int IdCliente);

    }
}

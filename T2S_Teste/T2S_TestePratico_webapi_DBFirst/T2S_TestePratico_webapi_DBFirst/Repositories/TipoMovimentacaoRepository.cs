using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2S_TestePratico_webapi_DBFirst.Contexts;
using T2S_TestePratico_webapi_DBFirst.Domains;
using T2S_TestePratico_webapi_DBFirst.Interfaces;

namespace T2S_TestePratico_webapi_DBFirst.Repositories
{
    public class TipoMovimentacaoRepository : ITipoMovimentacaoRepository
    {
        T2SContext ctx = new T2SContext();
        public void Atualizar(int idAtualizar, TipoMovimentacao tipomovimentacaoAtualizado)
        {
            TipoMovimentacao tipomovimentacaoAtual = BuscarPorId(idAtualizar);

            if (tipomovimentacaoAtual != null)
            {
                tipomovimentacaoAtual.Tipo = tipomovimentacaoAtualizado.Tipo;
            }

            ctx.TipoMovimentacaos.Update(tipomovimentacaoAtual);

            ctx.SaveChanges();

        }

        public TipoMovimentacao BuscarPorId(int id)
        {
            TipoMovimentacao tipomovimentacaoBuscado = ctx.TipoMovimentacaos.Find(id);

            return tipomovimentacaoBuscado;
        }

        public void Cadastrar(TipoMovimentacao novoTipoMovimentacao)
        {
            ctx.TipoMovimentacaos.Add(novoTipoMovimentacao);

            ctx.SaveChanges();
        }

        public void Deletar(int idDeletar)
        {
            ctx.TipoMovimentacaos.Remove(BuscarPorId(idDeletar));

            ctx.SaveChanges();

        }

        public List<TipoMovimentacao> Listar()
        {
            return ctx.TipoMovimentacaos.ToList();
        }
    }
}

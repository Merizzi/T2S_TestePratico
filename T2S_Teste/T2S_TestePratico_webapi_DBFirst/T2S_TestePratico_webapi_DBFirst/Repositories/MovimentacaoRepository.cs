using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2S_TestePratico_webapi_DBFirst.Contexts;
using T2S_TestePratico_webapi_DBFirst.Domains;
using T2S_TestePratico_webapi_DBFirst.Interfaces;

namespace T2S_TestePratico_webapi_DBFirst.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        T2SContext ctx = new T2SContext();
        public void Atualizar(int idAtualizar, Movimentacao movimentacaoAtualizado)
        {
            Movimentacao movimentacaoAtual = BuscarPorId(idAtualizar);

            if (movimentacaoAtual != null)
            {
                movimentacaoAtual.DataHoraInicio = movimentacaoAtualizado.DataHoraInicio;
                movimentacaoAtual.DataHoraFim= movimentacaoAtualizado.DataHoraFim;
                movimentacaoAtual.IdTipoMovimentacao = movimentacaoAtualizado.IdTipoMovimentacao;
            }

            ctx.Movimentacaos.Update(movimentacaoAtual);

            ctx.SaveChanges();

        }

        public Movimentacao BuscarPorId(int id)
        {
            Movimentacao movimentacaoBuscado = ctx.Movimentacaos.Find(id);

            return movimentacaoBuscado;
        }

        public void Cadastrar(Movimentacao novoMovimentacao)
        {
            ctx.Movimentacaos.Add(novoMovimentacao);

            ctx.SaveChanges();
        }

        public void Deletar(int idDeletar)
        {
            ctx.Movimentacaos.Remove(BuscarPorId(idDeletar));

            ctx.SaveChanges();

        }

        public List<Movimentacao> Listar()
        {
            return ctx.Movimentacaos.Include(m => m.IdTipoMovimentacaoNavigation).ToList();
        }

        public List<Movimentacao> BuscarIdCliente (int IdCliente)
        {
                return ctx.Movimentacaos
                    .Where(m => m.IdCliente == IdCliente)
                    .Include(m => m.IdTipoMovimentacaoNavigation)
                    .ToList();   
        }


    }
}

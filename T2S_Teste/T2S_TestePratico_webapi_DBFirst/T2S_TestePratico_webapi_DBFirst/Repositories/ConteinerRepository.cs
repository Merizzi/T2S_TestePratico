using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2S_TestePratico_webapi_DBFirst.Contexts;
using T2S_TestePratico_webapi_DBFirst.Domains;
using T2S_TestePratico_webapi_DBFirst.Interfaces;

namespace T2S_TestePratico_webapi_DBFirst.Repositories
{
    public class ConteinerRepository : IConteinerRepository
    {
        T2SContext ctx = new T2SContext();
        public void Atualizar(int idAtualizar, Conteiner conteinerAtualizado)
        {
            Conteiner conteinerAtual = BuscarPorId(idAtualizar);

            if (conteinerAtual != null)
            {
                conteinerAtual.NumeroConteiner = conteinerAtualizado.NumeroConteiner;
                conteinerAtual.IdCliente = conteinerAtualizado.IdCliente;
                conteinerAtual.StatusConteiner = conteinerAtualizado.StatusConteiner;
            }

            ctx.Conteiners.Update(conteinerAtual);

            ctx.SaveChanges();

        }

        public Conteiner BuscarPorId(int id)
        {
            Conteiner conteinerBuscado = ctx.Conteiners.Find(id);

            return conteinerBuscado;
        }

        public void Cadastrar(Conteiner novoConteiner)
        {
            ctx.Conteiners.Add(novoConteiner);

            ctx.SaveChanges();
        }

        public void Deletar(int idDeletar)
        {
            ctx.Conteiners.Remove(BuscarPorId(idDeletar));

            ctx.SaveChanges();

        }

        public List<Conteiner> Listar()
        {
            return ctx.Conteiners.ToList();
        }

    }
}

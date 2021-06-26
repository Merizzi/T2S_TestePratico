using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2S_TestePratico_webapi_DBFirst.Contexts;
using T2S_TestePratico_webapi_DBFirst.Domains;
using T2S_TestePratico_webapi_DBFirst.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace T2S_TestePratico_webapi_DBFirst.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        T2SContext ctx = new T2SContext();
        public void Atualizar(int idAtualizar, Cliente clienteAtualizado)
        {
            Cliente clienteAtual = BuscarPorId(idAtualizar);

            if (clienteAtual != null)
            {
                clienteAtual.Nome = clienteAtualizado.Nome;
                clienteAtual.Senha = clienteAtualizado.Senha;
            }

            ctx.Clientes.Update(clienteAtual);

            ctx.SaveChanges();
            
        }

        public Cliente BuscarPorId(int id)
        {
            Cliente clienteBuscado = ctx.Clientes.Find(id);

            return clienteBuscado;
        }

        public void Cadastrar(Cliente novoCliente)
        {
            ctx.Clientes.Add(novoCliente);

            ctx.SaveChanges();
        }

        public void Deletar(int idDeletar)
        {
            ctx.Clientes.Remove(BuscarPorId(idDeletar));

            ctx.SaveChanges();

        }

        public List<Cliente> Listar()
        {
            return ctx.Clientes.ToList();
        }
    }
}

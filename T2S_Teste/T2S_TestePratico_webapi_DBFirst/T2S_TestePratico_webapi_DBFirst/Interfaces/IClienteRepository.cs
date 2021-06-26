using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2S_TestePratico_webapi_DBFirst.Domains;

namespace T2S_TestePratico_webapi_DBFirst.Interfaces
{
    interface IClienteRepository
    {
        List<Cliente> Listar();

        Cliente BuscarPorId(int id);

        void Cadastrar(Cliente novoCliente);

        void Atualizar(int id, Cliente clienteAtualizado);

        void Deletar(int idDeletar);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2S_TestePratico_webapi_DBFirst.Domains;

namespace T2S_TestePratico_webapi_DBFirst.Interfaces
{
    interface IConteinerRepository
    {
        List<Conteiner> Listar();

        Conteiner BuscarPorId(int id);

        void Cadastrar(Conteiner novoConteiner);

        void Atualizar(int id, Conteiner conteinerAtualizado);

        void Deletar(int idDeletar);

    }
}

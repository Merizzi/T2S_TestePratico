using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2S_TestePratico_webapi_DBFirst.Domains;
using T2S_TestePratico_webapi_DBFirst.Interfaces;
using T2S_TestePratico_webapi_DBFirst.Repositories;

namespace T2S_TestePratico_webapi_DBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacaosController : ControllerBase
    {
        private IMovimentacaoRepository _movimentacaoRepository { get; set; }

        public MovimentacaosController()
        {
            _movimentacaoRepository = new MovimentacaoRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_movimentacaoRepository.Listar());
        }

        [HttpGet("clientes/{id}")]
        public IActionResult BuscarIdCliente(int id)
        {
            return Ok(_movimentacaoRepository.BuscarIdCliente(id)); 
        }


        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            try
            {
                Movimentacao movimentacaoBuscado = _movimentacaoRepository.BuscarPorId(id);

                if (movimentacaoBuscado != null)
                {
                    return Ok(movimentacaoBuscado);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return NotFound("Nenhuma movimentação foi encontrada.");
        }

        [HttpPost]
        public IActionResult Cadastrar(Movimentacao novoMovimentacao)
        {
            try
            {
                _movimentacaoRepository.Cadastrar(novoMovimentacao);

                return StatusCode(201, novoMovimentacao);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Movimentacao movimentacaoAtualizado)
        {
            try
            {
                Movimentacao movimentacaoBuscado = _movimentacaoRepository.BuscarPorId(id);

                if (movimentacaoBuscado != null)
                {
                    _movimentacaoRepository.Atualizar(id, movimentacaoAtualizado);

                    return StatusCode(204, movimentacaoAtualizado);
                }

                return NotFound("Nenhuma movimentação encontrada pelo o ID informado.");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                Movimentacao movimentacaoBuscado = _movimentacaoRepository.BuscarPorId(id);

                if (movimentacaoBuscado != null)
                {
                    _movimentacaoRepository.Deletar(id);

                    return StatusCode(202, movimentacaoBuscado);
                }

                return NotFound("Nenhuma movimentação encontrada para o ID informado.");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}

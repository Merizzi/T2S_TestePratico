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
    public class TipoMovimentacaosController : ControllerBase
    {
        private ITipoMovimentacaoRepository _tipomovimentacaoRepository { get; set; }

        public TipoMovimentacaosController()
        {
            _tipomovimentacaoRepository = new TipoMovimentacaoRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_tipomovimentacaoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            try
            {
                TipoMovimentacao tipomovimentacaoBuscado = _tipomovimentacaoRepository.BuscarPorId(id);

                if (tipomovimentacaoBuscado != null)
                {
                    return Ok(tipomovimentacaoBuscado);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return NotFound("Nenhum tipo movimentação foi encontrado.");
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoMovimentacao novoTipoMovimentacao)
        {
            try
            {
                _tipomovimentacaoRepository.Cadastrar(novoTipoMovimentacao);

                return StatusCode(201, novoTipoMovimentacao);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TipoMovimentacao tipomovimentacaoAtualizado)
        {
            try
            {
                TipoMovimentacao tipomovimentacaoBuscado = _tipomovimentacaoRepository.BuscarPorId(id);

                if (tipomovimentacaoBuscado != null)
                {
                    _tipomovimentacaoRepository.Atualizar(id, tipomovimentacaoAtualizado);

                    return StatusCode(204, tipomovimentacaoAtualizado);
                }

                return NotFound("Nenhum tipo movimentação foi encontrado pelo o ID informado.");
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
                TipoMovimentacao tipomovimentacaoBuscado = _tipomovimentacaoRepository.BuscarPorId(id);

                if (tipomovimentacaoBuscado != null)
                {
                    _tipomovimentacaoRepository.Deletar(id);

                    return StatusCode(202, tipomovimentacaoBuscado);
                }

                return NotFound("Nenhum tipo de movimentação foi encontrado pelo ID informado.");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2S_TestePratico_webapi_DBFirst.Interfaces;
using T2S_TestePratico_webapi_DBFirst.Repositories;
using T2S_TestePratico_webapi_DBFirst.Domains;

namespace T2S_TestePratico_webapi_DBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConteinersController : ControllerBase
    {

            private IConteinerRepository _conteinerRepository { get; set; }

            public ConteinersController()
            {
            _conteinerRepository = new ConteinerRepository();
            }

            [HttpGet]
            public IActionResult Listar()
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_conteinerRepository.Listar());
            }

            [HttpGet("{id}")]
            public IActionResult ListarPorId(int id)
            {
                try
                {
                    Conteiner conteinerBuscado = _conteinerRepository.BuscarPorId(id);

                    if (conteinerBuscado != null)
                    {
                        return Ok(conteinerBuscado);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

                return NotFound("Nenhum Conteiner foi encontrado.");
            }

            [HttpPost]
            public IActionResult Cadastrar(Conteiner novoConteiner)
            {
                try
                {
                    _conteinerRepository.Cadastrar(novoConteiner);

                    return StatusCode(201, novoConteiner);
                }
                catch (Exception error)
                {
                    return BadRequest(error);
                }
            }

            [HttpPut("{id}")]
            public IActionResult Atualizar(int id, Conteiner conteinerAtualizado)
            {
                try
                {
                    Conteiner conteinerBuscado = _conteinerRepository.BuscarPorId(id);

                    if (conteinerBuscado != null)
                    {
                        _conteinerRepository.Atualizar(id, conteinerAtualizado);

                        return StatusCode(204, conteinerAtualizado);
                    }

                    return NotFound("Nenhum conteiner encontrado para o ID informado.");
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
                    Conteiner conteinerBuscado = _conteinerRepository.BuscarPorId(id);

                    if (conteinerBuscado != null)
                    {
                        _conteinerRepository.Deletar(id);

                        return StatusCode(202, conteinerBuscado);
                    }

                    return NotFound("Nenhum conteiner encontrado para o ID informado.");
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
        
    }
}

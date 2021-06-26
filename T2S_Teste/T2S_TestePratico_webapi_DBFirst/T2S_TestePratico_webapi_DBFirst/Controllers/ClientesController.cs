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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClienteRepository _clienteRepository { get; set; }

        public ClientesController()
        {
            _clienteRepository = new ClienteRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_clienteRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            try
            {
                Cliente clienteBuscado = _clienteRepository.BuscarPorId(id);

                if (clienteBuscado != null)
                {
                    return Ok(clienteBuscado);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return NotFound("Nenhum Cliente foi encontrado.");
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente novoCliente)
        {
            try
            {
                _clienteRepository.Cadastrar(novoCliente);

                return StatusCode(201, novoCliente);
            }
            catch(Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Cliente clienteAtualizado)
        {
            try
            {
                Cliente clienteBuscado = _clienteRepository.BuscarPorId(id);
                
                if(clienteBuscado != null)
                {
                    _clienteRepository.Atualizar(id, clienteAtualizado);

                    return StatusCode(204, clienteAtualizado);
                }

                return NotFound("Nenhum cliente encontrado para o ID informado.");
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
                Cliente clienteBuscado = _clienteRepository.BuscarPorId(id);

                if (clienteBuscado != null)
                {
                    _clienteRepository.Deletar(id);

                    return StatusCode(202, clienteBuscado);
                }

                return NotFound("Nenhum cliente encontrado para o ID informado.");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}

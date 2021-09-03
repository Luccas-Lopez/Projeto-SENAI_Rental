using Microsoft.AspNetCore.Mvc;
using senai_Rental_webAPI.Domains;
using senai_Rental_webAPI.Interfaces;
using senai_Rental_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlugueisController : ControllerBase
    {
        private IAluguelRepository _aluguelRepository { get; set; }
        public AlugueisController()
        {
            _aluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomain> listaAluguel = _aluguelRepository.ListarTodos();

            return Ok(listaAluguel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AluguelDomain aluguelBuscado = _aluguelRepository.BuscarPorId(id);

            if (aluguelBuscado == null)
            {
                return NotFound("Nenhum aluguel foi encontrado!");
            }

            return Ok(aluguelBuscado);
        }

        [HttpPost]
        public IActionResult Post(AluguelDomain novoAluguel)
        {

            _aluguelRepository.Cadastrar(novoAluguel);

            return StatusCode(201);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _aluguelRepository.Deletar(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult PutIdBody(AluguelDomain aluguelAtualizado)
        {
            if (aluguelAtualizado.idAluguel <= 0 || aluguelAtualizado.idCliente <= 0 || aluguelAtualizado.idVeiculo <= 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Informações insuficientes, preencha corretamente!"
                    });
            }

            AluguelDomain aluguelBuscado = _aluguelRepository.BuscarPorId(aluguelAtualizado.idAluguel);

            if (aluguelBuscado != null)
            {
                try
                {
                    _aluguelRepository.AtualizarIdCorpo(aluguelAtualizado);

                    return NoContent();
                }
                catch (Exception codErro)
                {
                    return BadRequest(codErro);
                }
            }

            return NotFound(
                    new
                    {
                        mensagem = "Aluguel não disponível para consulta!",
                        errorStatus = true
                    }
                );
        }
    }
}
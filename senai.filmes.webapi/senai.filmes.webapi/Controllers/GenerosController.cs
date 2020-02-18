using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using senai.Filmes.WebApi.Repositories;

namespace senai.Filmes.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos generos
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _generoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        /// dominio/api/Generos
        [HttpGet]
        public IEnumerable<GeneroDomain> Get()
        {
            // Faz a chamada para o método .Listar();
            return _generoRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(GeneroDomain generoRecebido)
        {
            _generoRepository.Adicionar(generoRecebido);
            return StatusCode(201);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            GeneroDomain GeneroBuscado = _generoRepository.BuscarPorId(Id);
            
            if(GeneroBuscado == null)
            {
                return StatusCode(404, "Nenhum Genero Encontrado");
            }

            return StatusCode(200, GeneroBuscado);
        }

        [HttpPut("{Id}")]
        public IActionResult PutIdURL(int Id, GeneroDomain generoAtualizado)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(Id);

            if(generoBuscado == null)
            {
                return StatusCode(404, "Genero nao encontrado");
            }

            try
            {
                _generoRepository.AtualizarIdURL(Id, generoAtualizado);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutIdCorpo(GeneroDomain generoAtualizado)
        {
            _generoRepository.AtualizarIdCorpo(generoAtualizado);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            return Ok("Genero Deletado");
        }
    }
}
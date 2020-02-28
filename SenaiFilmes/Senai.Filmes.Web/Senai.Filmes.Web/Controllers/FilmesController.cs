using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.Web.Domains;
using Senai.Filmes.Web.Interfaces;
using Senai.Filmes.Web.Repositories;

namespace Senai.Filmes.Web.Controllers
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
    public class FilmesController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _generoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        /// dominio/api/Generos
        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {
            // Faz a chamada para o método .Listar();
            return _filmeRepository.ListarFilmes();
        }

        //Cadastrar ndo um novo filme 
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            FilmeDomain generoBuscado = _filmeRepository.BuscarPorId(novoFilme.IdGenero);

            if (generoBuscado == null)
            {
                return NotFound("Genero não existe");
            }

            // Faz a chamada para o método .CadastrarFilme();
            _filmeRepository.CadastrarFilme(novoFilme);

            return Ok("Filme cadastrado");
        }

        /// <summary>
        /// Busca um gênero através do seu ID
        /// </summary>
        /// <param name="id">ID do gênero buscado</param>
        /// <returns>Retorna um gênero buscado</returns>
        /// dominio/api/Generos/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            FilmeDomain generoBuscado = _filmeRepository.BuscarFilmePorId(id);

            // Verifica se nenhum gênero foi encontrado
            if (generoBuscado == null)
            {
                // Caso não seja encontrado, retorna um status code 404 com a mensagem personalizada
                return NotFound("Nenhum gênero encontrado");
            }

            // Caso seja encontrado, retorna o gênero buscado
            return Ok(generoBuscado);
        }
    }
}
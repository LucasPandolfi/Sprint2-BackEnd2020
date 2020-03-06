using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.WebApi.DbFirst.Domains;
using Senai.WebApi.DbFirst.Interfaces;
using Senai.WebApi.DbFirst.Repositories;

namespace Senai.WebApi.DbFirst.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class JogosController : ControllerBase
    {

        private IJogosRepository _jogosRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogosRepository.ListarJogos());
        }

        [HttpPost]
        public IActionResult Post(Jogos NovoJogo)
        {
            _jogosRepository.CadastrarJogo(NovoJogo);

            return StatusCode(201);

        }

        [HttpPut]
        public IActionResult Put(Jogos JogoAtualizado)
        {
            Jogos JogoBuscado = _jogosRepository.BuscarJogoPorId(JogoAtualizado.IdJogo);
            if(JogoBuscado == null)
            {
                return NotFound();
            }
            _jogosRepository.AtualizarJogo( JogoAtualizado);

            return Ok(JogoAtualizado);
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            Jogos JogoBuscado = _jogosRepository.BuscarJogoPorId(id);
            if (JogoBuscado == null)
            {
                return NotFound();
            }
            _jogosRepository.BuscarJogoPorId(id);

            return Ok(JogoBuscado);
        }
    }
}
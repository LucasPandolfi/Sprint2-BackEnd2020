using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using Senai.Gufi.WebApi.Repositories;

namespace Senai.Gufi.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class PresencasController : ControllerBase
    {
        IPresencaRepository _presencaRepository;
        IUsuarioRepository _usuarioRepository;
        IEventoRepository _eventoRepository;


        public PresencasController()
        {
            _presencaRepository = new PresencaRepository();
            _usuarioRepository = new UsuarioRepository();
            _eventoRepository = new EventoRepository();
        }


        [HttpPost("{id}")]
        public IActionResult Post(Presenca novoConvite)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(novoConvite.IdUsuario);

            Evento EventoBuscado = _eventoRepository.BuscarEventoPorId(novoConvite.IdEvento);

            if(usuarioBuscado == null && EventoBuscado == null)
            {
                return NotFound();
            }

            _presencaRepository.Convidar(novoConvite);

            return StatusCode(200);
        }
    }
}
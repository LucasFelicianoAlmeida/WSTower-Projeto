using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTower.Domains;
using WSTower.Repositories;

namespace WSTower.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : ControllerBase
    {
        JogadorRepository _jogadorRepository = new JogadorRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_jogadorRepository = new JogadorRepository());
        }

        [Route("PorNome/{nome}")]
        [HttpGet("{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            if(nome != null)
            {
                return Ok(_jogadorRepository.BuscarPorNome(nome));
            }
            return NotFound("O nome sugerido não foi solicitado");
        }

        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                Jogador jogadorBuscado = _jogadorRepository.BuscarPorId(id);

                if (jogadorBuscado != null)
                {
                    return Ok(jogadorBuscado);
                }
                return NotFound("O Usuário não foi encontrado.");

            }
            catch (Exception error)
            {
                return BadRequest(error);
            }


        }
        [HttpPost]
        public IActionResult Cadastra(Jogador jogador)
        {
            _jogadorRepository.Cadastrar(jogador);
            return Ok();
        }

    }     
}
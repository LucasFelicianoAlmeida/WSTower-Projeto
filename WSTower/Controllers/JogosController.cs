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
    public class JogosController : ControllerBase
    {
        JogoRepository _jogoRepository = new JogoRepository();

        /// <summary>
        /// Lista todos os Jogos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok(_jogoRepository.Listar());
        }

        /// <summary>
        /// Lista os Jogo pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                Jogo jogoBuscado = _jogoRepository.BuscarPorId(id);

                if (jogoBuscado != null)
                {
                    return Ok(jogoBuscado);
                }
                return NotFound("O Usuário não foi encontrado.");

            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Jogo Buscado pela Data
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [Route("PorData/{date}")]
        [HttpGet("{date}")]
        public IActionResult BuscaPorData(string date)
        {
            try
            {
                 
                if(date != null)
                {
                    return Ok(_jogoRepository.BuscarPorData(date));
                }
                return NotFound("Data não encontrada");
            }
            catch(Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Jogo Buscado pelo Estadio
        /// </summary>
        /// <param name="estadio"></param>
        /// <returns></returns>
        [Route("PorEstadio/{estadio}")]
        [HttpGet("{estadio}")]
        public IActionResult BuscaPeloEstadio(string estadio)
        {
            

            if(estadio != null)
            {

            return Ok(_jogoRepository.BuscarPorEstadio(estadio));
            }
            return NotFound("Não há nenhum jogo com esse estádio.");

        }

        [Route("PorSelecao/{selecao}")]
        [HttpGet("{selecao}")]
        public IActionResult BuscaPelaSelecao(int selecao)
        {
            
                return Ok(_jogoRepository.BuscaPorSelecao(selecao));
          
        }


        /// <summary>
        /// Adiciona um novo Usuário
        /// </summary>
        /// <param name="novoJogo"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Adiciona(Jogo novoJogo)
        {
            _jogoRepository.Cadastrar(novoJogo);
            return Ok();

        }

        /// <summary>
        /// Atualiza um Jogo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jogoAtualizado"></param>
        /// <returns></returns>
        //[HttpPut("{id}")]
        //public IActionResult Atualiza(int id, Jogo jogoAtualizado)
        //{
        //    try
        //    {

        //        Jogo jogoBuscado = _jogoRepository.BuscarPorId(id);

        //        if (jogoBuscado != null)
        //        {

        //            _jogoRepository.Atualizar(id, jogoAtualizado);

        //            return StatusCode(204);

        //        }
        //        return NotFound("O Jogo não foi encontrado");
        //    }

        //    catch (Exception error)
        //    {
        //        return BadRequest(error);
        //    }
        //}

        /// <summary>
        /// Deleta um Jogo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Deleta(int id)
        {
            try
            {
                Jogo jogoBuscado = _jogoRepository.BuscarPorId(id);
                if (jogoBuscado != null)
                {
                    _jogoRepository.Deletar(id);
                    return Ok();
                }
                return NotFound("O Usuário não foi encontrado para o ID adicionado.");

            }
            catch (Exception error)
            {
                return BadRequest(error);
            }


        }
    }
}
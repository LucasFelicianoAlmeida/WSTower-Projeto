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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SelecoesController : ControllerBase
    {
        SelecaoRepository _selecaoRepository = new SelecaoRepository();

        //Listar as seleções
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_selecaoRepository.Listar());
        }

        //Busca as seleções por Id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {

                Selecao selecaoBuscada = _selecaoRepository.BuscarPorId(id);

                if(selecaoBuscada != null)
                {

                    return Ok(selecaoBuscada);

                }
                return NotFound("Nenhuma seleçao encontrada");

            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        //Cadastrar as seleções 
        [HttpPost]
        public IActionResult Cadastrar(Selecao novaSelecao)
        {
            _selecaoRepository.Cadastrar(novaSelecao);
            return Ok();
        }
        
        
        //Atualizar as seleções
        [HttpPut("{id}")]
        public  IActionResult Atualizar(int id, Selecao selecaoAtualizada)
        {
            try
            {
            Selecao selecaoBuscada = _selecaoRepository.BuscarPorId(id);
            
                if (selecaoBuscada != null)
                {

                    
                    _selecaoRepository.Atualizar(id,selecaoAtualizada);
                return Ok();
                }
                return NotFound("Nenhuma seleçao encontrada pelo ID");
                
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Deletar as seleções
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                Selecao selecaoBuscada = _selecaoRepository.BuscarPorId(id);
                if (selecaoBuscada != null)
                {
                    _selecaoRepository.Deletar(id);

                    //returno o Status Code 
                    return StatusCode(202);
                }

                return NotFound("Selecao não encontrada");
            }

            catch (Exception error)
            {
                return BadRequest(error);
            }


        }
    }
}
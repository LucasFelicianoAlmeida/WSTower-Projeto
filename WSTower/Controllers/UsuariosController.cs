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
    public class UsuariosController : ControllerBase
    {
        UsuarioRepository _usuarioRepository = new UsuarioRepository();

        //Lista os Usuario
        [HttpGet]
        public IActionResult  ListarTodos()
        {
            
            return Ok(_usuarioRepository.Listar());
        }

        //Lista os Usuario pelo Id
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if(usuarioBuscado != null)
                {
                    return Ok(usuarioBuscado);
                }
                return NotFound("O Usuário não foi encontrado.");

            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        //Adiciona um novo Usuário
        [HttpPost]
        public IActionResult Adiciona(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);
            return Ok();

        }

        //Atualiza um Usuário
        [HttpPut("{id}")]
        public IActionResult Atualiza(int id, Usuario usuarioAtualizado)
        {
            try
            {

            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if(usuarioBuscado != null)
            {

                    _usuarioRepository.Atualizar(id, usuarioAtualizado);

                return StatusCode(204);

            }
                return NotFound("O Usuario não foi encontrado");
            }

            catch(Exception error)
            {
                return BadRequest(error);
            }
        }

        //Deleta um Usuario
        [HttpDelete("{id}")]
        public IActionResult Deleta(int id)
        {
            try
            {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);
                if(usuarioBuscado != null)
                {
                    _usuarioRepository.Deletar(id);
                    return Ok();
                }
                return NotFound("O Usuário não foi encontrado para o ID adicionado.");

            }
            catch(Exception error)
            {
                return BadRequest(error);
            }

            
        }

        [HttpPost]
        [Route("LoginViewModel")]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            Usuario usuario = _usuarioRepository.BuscarPorEmailSenha(loginViewModel);

            if (usuario == null)
            {
                return NotFound("Senha ou Email incorreto");
            }
            return Ok("Você Logou!!!!");

        }


    }
}
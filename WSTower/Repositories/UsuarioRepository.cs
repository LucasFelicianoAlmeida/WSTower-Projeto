using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Contexts;
using WSTower.Domains;

namespace WSTower.Repositories
{
    public class UsuarioRepository
    {
        //Lista todos os Usuarios
        public List<Usuario> Listar()
        {
            using(CampeonatoContex ctx = new CampeonatoContex())
            {
                return ctx.Usuario.ToList();

            }
        }

        //Cadastra um novo Usuario
        public void Cadastrar(Usuario usuario)
        {
            using(CampeonatoContex ctx = new CampeonatoContex())
            {
                ctx.Usuario.Add(usuario);

                ctx.SaveChanges();
            }
        }

        //Deleta um Usuario
        public void Deletar(int id)
        {
            using(CampeonatoContex ctx = new CampeonatoContex())
            {
                //Remove o Ususario o buscado pelo Id
                ctx.Usuario.Remove(BuscarPorId(id));

                ctx.SaveChanges();
            }
        }

        //Atualiza os dados do Usuario
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            using(CampeonatoContex ctx = new CampeonatoContex())
            {
                
                Usuario usuarioBuscado = ctx.Usuario.Find(id);
                if(usuarioBuscado != null)
                {

                    if(usuarioBuscado.Nome != null)
                    {
                        usuarioBuscado.Nome = usuarioAtualizado.Nome;
                    }

                    if(usuarioBuscado.Senha != null)
                    {
                        usuarioBuscado.Senha = usuarioAtualizado.Senha;
                    }

                    if(usuarioBuscado.Foto != null)
                    {
                        usuarioBuscado.Foto = usuarioAtualizado.Foto;
                    }

                    if(usuarioBuscado.Email != null)
                    {
                        usuarioBuscado.Email = usuarioAtualizado.Email;
                    }

                    
                    ctx.Usuario.Update(usuarioBuscado);
                    ctx.SaveChanges();   
                }
            }
        }

        //Buscar pelo Id
        public Usuario BuscarPorId(int id)
        {
            using (CampeonatoContex ctx = new CampeonatoContex())
            {
                return ctx.Usuario.FirstOrDefault(x => x.Id == id);
            }
        }

        public Usuario BuscarPorEmailSenha(LoginViewModel loginViewModel)
        {
            using (CampeonatoContex ctx = new CampeonatoContex())
            {
                return ctx.Usuario.FirstOrDefault(x => x.Email == loginViewModel.Email && x.Senha == loginViewModel.Senha);
            }
        }

    }
}

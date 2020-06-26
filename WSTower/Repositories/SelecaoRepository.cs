using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Contexts;
using WSTower.Domains;


namespace WSTower.Repositories
{
    public class SelecaoRepository 
    {

        //Lista todas as Seleçoes
        public List<Selecao> Listar()
        {
            using (CampeonatoContex ctx = new CampeonatoContex())
            {
                return ctx.Selecao.ToList();

            }
        }

        //Cadastra uma nova Selecao
        public void Cadastrar(Selecao selecao)
        {
            using (CampeonatoContex ctx = new CampeonatoContex())
            {
                ctx.Selecao.Add(selecao);
                ctx.SaveChanges();
            }
        }

        //Deleta uma Selecao
        public void Deletar(int id)
        {
            using (CampeonatoContex ctx = new CampeonatoContex())
            {
                ctx.Selecao.Remove(BuscarPorId(id));
                ctx.SaveChanges();
            }
        }

        public Selecao BuscarPorId(int id)
        {
            using(CampeonatoContex ctx = new CampeonatoContex())
            {
                return  ctx.Selecao.FirstOrDefault(x => x.Id == id);

            }
        }

        //Atualiza os dados da Selecao
        public void Atualizar(int id ,Selecao selecaoAtualizada)
        {
            using (CampeonatoContex ctx = new CampeonatoContex())
            {
                 
                Selecao selecaoBuscada = ctx.Selecao.Find(id);

                if (selecaoBuscada != null)
                {
                    //Nome
                    if (selecaoBuscada.Nome != null)
                    {
                        selecaoBuscada.Nome = selecaoAtualizada.Nome;
                    }

                    //Escalaçao
                    if(selecaoBuscada.Escalacao != null)
                    {
                        selecaoBuscada.Escalacao = selecaoAtualizada.Escalacao;
                    }
                    
                    //Bandeira
                    if(selecaoBuscada.Bandeira != null)
                    {
                        selecaoBuscada.Bandeira = selecaoAtualizada.Bandeira;
                    }

                    
                    //Uniforme
                    if(selecaoBuscada.Uniforme != null)
                    {
                        selecaoBuscada.Uniforme = selecaoAtualizada.Uniforme;
                    }
                    ctx.Selecao.Update(selecaoBuscada);
                    ctx.SaveChanges();
                }
            }
        }
    }
}

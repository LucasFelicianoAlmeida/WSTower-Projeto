using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Contexts;
using WSTower.Domains;

namespace WSTower.Repositories
{
    public class JogoRepository
    {
        
        /// <summary>
        /// Lista os Jogos
        /// </summary>
        /// <returns></returns>
        public List<Jogo> Listar()
        {
            using (CampeonatoContex ctx = new CampeonatoContex())
            {
                return ctx.Jogo.ToList();

            }
        }

        /// <summary>
        /// Cadastra um novo Jogo
        /// </summary>
        /// <param name="jogo"></param>
        public void Cadastrar(Jogo jogo)
        {
            using (CampeonatoContex ctx = new CampeonatoContex())
            {
                ctx.Jogo.Add(jogo);

                ctx.SaveChanges();
            }
        }
        /// <summary>
        /// Busca um jogo pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Jogo BuscarPorId(int id)
        {
            using (CampeonatoContex ctx = new CampeonatoContex())
            {
                return ctx.Jogo.FirstOrDefault(x => x.Id == id);
            }

        }

        

        public List<Jogo> BuscarPorData(string date)
        {
            using (CampeonatoContex ctx = new CampeonatoContex())
            {

                return ctx.Jogo.Where(x => x.Data == DateTime.Parse(date)).ToList();
            }
        }

        public List<Jogo> BuscarPorEstadio(string Estadio)
        {
            using (CampeonatoContex ctx = new CampeonatoContex())
            {

                return ctx.Jogo.Where(u => u.Estadio == Estadio).ToList();
                    
            }
        }

        public List<Jogo> BuscaPorSelecao(int selecao)
        {
            using(CampeonatoContex ctx = new CampeonatoContex())
            {
                return ctx.Jogo.Where(x => x.SelecaoCasa == selecao || x.SelecaoVisitante == selecao).ToList();
            }
        }

        /// <summary>
        /// Deleta um Jogo
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (CampeonatoContex ctx = new CampeonatoContex())
            {
                //Remove o Ususario o buscado pelo Id
                ctx.Jogo.Remove(BuscarPorId(id));

                ctx.SaveChanges();
            }
        }

        //public void Atualizar(int id,Jogo jogoAtualizado)
        //{
        //    using (CampeonatoContex ctx = new CampeonatoContex())
        //    {
        //        Jogo jogoBuscado = ctx.Jogo.Find(id);

        //        if(jogoBuscado != null)
        //        {
        //            if(jogoBuscado.PenaltisCasa != null)
        //            {
        //                jogoAtualizado.PenaltisCasa = jogoBuscado.PenaltisCasa;
        //            }

        //            if (jogoBuscado.PenaltisVisitante != null)
        //            {
        //                jogoAtualizado.PenaltisVisitante = jogoBuscado.PenaltisVisitante;
        //            }

        //            if (jogoBuscado.PlacarCasa != null)
        //            {
        //                jogoAtualizado.PlacarCasa = jogoBuscado.PlacarCasa;
        //            }

        //            if (jogoBuscado.PlacarVisitante != null)
        //            {
        //                jogoAtualizado.PlacarVisitante = jogoBuscado.PlacarVisitante;
        //            }

        //            if (jogoBuscado.SelecaoCasa != null)
        //            {
        //                jogoAtualizado.SelecaoCasa = jogoBuscado.SelecaoCasa;
        //            }

        //            if (jogoBuscado.SelecaoVisitante != null)
        //            {
        //                jogoAtualizado.SelecaoVisitante = jogoBuscado.SelecaoVisitante;
        //            }


        //            ctx.Jogo.Update(jogoBuscado);
        //            ctx.SaveChanges();

        //        }
        //    }
        //}

    }
}

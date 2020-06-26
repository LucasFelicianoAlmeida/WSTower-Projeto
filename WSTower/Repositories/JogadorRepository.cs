using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Contexts;
using WSTower.Domains;

namespace WSTower.Repositories
{
    public class JogadorRepository
    {
        public List<Jogador> ListarJogadores()
        {
            using (CampeonatoContex ctx = new CampeonatoContex())
            {
                return ctx.Jogador.ToList();

            }
        }

        public List<Jogador> BuscarPorNome(string nome)
        {
            using (CampeonatoContex ctx = new CampeonatoContex())
            {
                return ctx.Jogador.Where(x => x.Nome == nome).ToList();
            }

        }

        public void Cadastrar(Jogador jogador)
        {
            using (CampeonatoContex ctx = new CampeonatoContex())
            {
                ctx.Jogador.Add(jogador);

                ctx.SaveChanges();
            }
        }

        public Jogador BuscarPorId(int id)
        {
            using (CampeonatoContex ctx = new CampeonatoContex())
            {
                return ctx.Jogador.FirstOrDefault(x => x.Id == id);
            }

        }


    }
}

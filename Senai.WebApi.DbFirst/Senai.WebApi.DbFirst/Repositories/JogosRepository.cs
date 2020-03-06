using Senai.WebApi.DbFirst.Domains;
using Senai.WebApi.DbFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.DbFirst.Repositories
{
    public class JogosRepository : IJogosRepository
    {

        private InLockContext ctx = new InLockContext();

        public void AtualizarJogo(Jogos AtualizarJogo)
        {
            ctx.SaveChanges();
            ctx.Jogos.Update(AtualizarJogo);
            ctx.SaveChanges();
        }

        public Jogos BuscarJogoPorId(int id)
        {
            return ctx.Jogos.Single(Jogos => Jogos.IdJogo == id);
        }

        public List<Jogos> ListarJogos()
        {
            return ctx.Jogos.ToList();
        }

        void IJogosRepository.CadastrarJogo(Jogos CadastrarJogo)
        {
            ctx.Jogos.Add(CadastrarJogo);

            ctx.SaveChanges();
        }
    }
}

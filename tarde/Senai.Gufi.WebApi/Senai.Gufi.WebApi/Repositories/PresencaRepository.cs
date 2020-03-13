using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {

        GufiContext ctx = new GufiContext();

        public void AtualizarPresenca(int id, Presenca tipoPresencaAtualizado)
        {
            throw new NotImplementedException();
        }

        public Presenca BuscarPorId(int id)
        {
            return ctx.Presenca.FirstOrDefault(p => p.IdPresenca == id);
        }

        public void CadastrarPresenca(Presenca novoTipoPresenca)
        {
            throw new NotImplementedException();
        }

        public void Convidar(Presenca novoConvite)
        {
            ctx.Presenca.Add(novoConvite);

            ctx.SaveChanges();
        }

        public void DeletarPresenca(int id)
        {
            throw new NotImplementedException();
        }

        public void Inscricao(Presenca novaInscricao)
        {
            throw new NotImplementedException();
        }

        public List<Presenca> ListarPresenca()
        {
            throw new NotImplementedException();
        }
    }
}

using Senai.WebApi.DbFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WebApi.DbFirst.Interfaces
{
    interface IJogosRepository
    {
        List<Jogos> ListarJogos();

        void CadastrarJogo (Jogos CadastrarJogo);

        void AtualizarJogo ( Jogos AtualizarJogo);

        Jogos BuscarJogoPorId (int id);
    }
}

using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface IPresencaRepository
    {
        List<Presenca> ListarPresenca();

        void CadastrarPresenca(Presenca novoTipoPresenca);

        void AtualizarPresenca(int id, Presenca tipoPresencaAtualizado);

        void DeletarPresenca(int id);

        Presenca BuscarPorId(int id);

        void Inscricao(Presenca novaInscricao);

        void Convidar(Presenca novoConvite);
    }
}

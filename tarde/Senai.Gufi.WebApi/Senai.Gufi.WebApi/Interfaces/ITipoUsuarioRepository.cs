using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> ListarTipoUsuario();

        void CadastrarTipoUsuario(TipoUsuario novoTipoUsuario);

        void AtualizarTipoUsuario(int id, TipoUsuario tipoUsuarioAtualizado);

        void DeletarTipoUsuario(int id);

        TipoUsuario BuscarPorId(int id);
    }
}

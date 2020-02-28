using senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Peoples.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuarioDomain> ListarTiposUsuarios();

        TipoUsuarioDomain BuscarPorId(int id);

        void AtualizarTipoUsuario(int id, TipoUsuarioDomain tipoUsuarioAtualizado);

        void DeletarTipoUsuario(int id);
    }
}

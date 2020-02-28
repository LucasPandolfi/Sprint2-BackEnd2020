using senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Peoples.WebApi.Interfaces
{
    interface IUsuarioRepository 
    {
            /// <summary>
            /// Valida o usuário
            /// </summary>
            /// <param name="email">E-mail do usuário</param>
            /// <param name="senha">Senha do usuário</param>
            /// <returns>Retorna um usuário validado</returns>
            UsuarioDomain BuscarPorEmailSenha(string email, string senha);      
    }
}

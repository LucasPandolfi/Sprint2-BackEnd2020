using senai.Peoples.WebApi.Domains;
using senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Peoples.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao;

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna um usuário validado</returns>
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            // Define a conexão passando a string
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Define a query a ser executada no banco
                string querySelect = "SELECT IdUsuario, EmailUsuario, Senha, IdTipoUsuario FROM Usuarios WHERE EmailUsuario = @EmailUsuario AND Senha = @Senha";

                // Define o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define o valor dos parâmetros
                    cmd.Parameters.AddWithValue("@EmailUsario", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    // Abre a conexão com o banco
                    con.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Caso dados tenham sido obtidos
                    if (rdr.HasRows)
                    {
                        // Cria um objeto usuario
                        UsuarioDomain usuario = new UsuarioDomain();

                        // Enquanto estiver percorrendo as linhas
                        while (rdr.Read())
                        {
                            // Atribui à propriedade IdUsuario o valor da coluna IdUsuario
                            usuario.IdUsuario = Convert.ToInt32(rdr["IdUsuario"]);

                            // Atribui à propriedade Email o valor da coluna Email
                            usuario.EmailUsuario = rdr["EmailUsuario"].ToString();

                            // Atribui à propriedade Senha o valor da coluna Senha
                            usuario.Senha = rdr["Senha"].ToString();

                            // Atribui à propriedade Permissao o valor da coluna Permissao
                            usuario.IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]);
                        }

                        // Retorna o objeto usuario
                        return usuario;
                    }
                }

                // Caso não encontre um email e senha correspondente, retorna null
                return null;
            }
        }
    }
}

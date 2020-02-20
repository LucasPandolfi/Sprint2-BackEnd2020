using Senai.Filmes.Web.Domains;
using Senai.Filmes.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.Web.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source - Nome do Servidor
        /// initial catalog - Nome do Banco de Dados
        /// integrated security=true - Faz a autenticação com o usuário do sistema
        /// user Id=sa; pwd=sa@132 - Faz a autenticação com um usuário específico, passando o logon e a senha
        /// </summary>
        private string StringConexao = "Data Source=DEV7\\SQLEXPRESS; initial catalog=Filmes_tarde; user Id=sa; pwd=sa@132;";

        public List<FilmeDomain> ListarFilmes()
        {
            // Cria uma lista generos onde serão armazenados os dados
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string queryPegarFilmes = "SELECT IdFilme, Titulo, IdGenero FROM Filmes";

                //Abre a conexão com o banco de dados
                con.Open();

                //Definindo o comando que usaremos no banco - SqlDataReader irá percorrer o banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryPegarFilmes, con))
                {
                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        // Cria um objeto genero do tipo GeneroDomain
                        FilmeDomain filme = new FilmeDomain
                        {
                            // Atribui à propriedade IdGenero o valor da primeira coluna da tabela do banco
                            IdFilme = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            Titulo = rdr["Titulo"].ToString()
                        };
                        // Adiciona o genero criado à tabela generos
                        filmes.Add(filme);
                    }
                }
            }
            // Retorna a lista de generos
            return filmes;
        }


        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="genero">Objeto genero que será cadastrado</param>
        public void CadastrarFilme(FilmeDomain filme)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que será executada passando o valor como parâmetro, evitando assim os problemas acima
                string queryInsert = "INSERT INTO Filmes(Titulo), IdGenero VALUES (@Titulo)";

                // Declara o comando passando a query e a conexão
                SqlCommand cmd = new SqlCommand(queryInsert, con);

                // Passa o valor do parâmetro
                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                // Abre a conexão com o banco de dados
                con.Open();

                // Executa o comando
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Busca um gênero pelo ID
        /// </summary>
        /// <param name="id">ID do gênero que será buscado</param>
        /// <returns>Retorna um gênero buscado ou null caso não seja encontrado</returns>
        public FilmeDomain BuscarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT IdGenero FROM Filmes WHERE IdGenero = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader fazer a leitura no banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Caso a o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Cria um objeto genero
                        FilmeDomain genero = new FilmeDomain
                        {
                            // Atribui à propriedade IdGenero o valor da coluna "IdGenero" da tabela do banco
                            IdGenero = Convert.ToInt32(rdr["IdGenero"])
                        };

                        // Retorna o genero com os dados obtidos
                        return genero;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }
    }
}

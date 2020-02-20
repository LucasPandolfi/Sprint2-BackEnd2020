using Senai.Filmes.Web.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.Web.Interfaces
{
    interface IFilmeRepository
    {
        //Listando todos os filmes
        List<FilmeDomain> ListarFilmes();

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="filme">Objeto genero que será cadastrado</param>
        void CadastrarFilme(FilmeDomain filme);

        /// <summary>
        /// Busca um gênero através do ID
        /// </summary>
        /// <param name="id">ID do gênero que será buscado</param>
        /// <returns>Retorna um genero</returns>
        FilmeDomain BuscarPorId(int id);
    }
}

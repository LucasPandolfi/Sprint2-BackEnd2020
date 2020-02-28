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

        //Verificando se a id existe
        FilmeDomain BuscarPorId(int id);

        //Buscando filmes pela id
        FilmeDomain BuscarFilmePorId(int id);

        /// <summary>
        /// Atualiza um gênero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="Titulo">Objeto genero que será atualizado</param>
        void AtualizarIdCorpo(FilmeDomain genero);
    }
}

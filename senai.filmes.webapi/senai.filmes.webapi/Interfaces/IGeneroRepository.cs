using senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório Genero
    /// </summary>
    interface IGeneroRepository
    {
        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        List<GeneroDomain> Listar();

        void Adicionar(GeneroDomain genero);

        GeneroDomain BuscarPorId(int Id);

        void AtualizarIdCorpo(GeneroDomain genero);

        void AtualizarIdURL(int Id, GeneroDomain genero);

        void Deletar(int Id);
    }
}

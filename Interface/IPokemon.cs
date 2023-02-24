using System.Collections.Generic;
using Pokemon.Models;
using System.Text.Json;

namespace Pokemon.Interface
{

    public interface IPokemon
    {
        /// <summary>
        /// Gets Pokemons.
        /// </summary>
        /// <returns>A list of Pokemon.</returns>
        Task <Response<PokemonModel>> GetPokemon();
        /// <summary>
        /// Gets Pokemon details.
        /// </summary>
        /// <returns>A list of Pokemon details.</returns>
        Task<object> GetPokemonDetail(string pokemoneName);


    }

    public interface PokemonList
    {
    }
}

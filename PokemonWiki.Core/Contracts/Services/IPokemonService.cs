using PokemonWiki.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokemonWiki.Core.Constants.Contracts
{
    public interface IPokemonService
    {
        Task<IEnumerable<PokemonDto>> GetPokemonsAsync();
        Task<PokemonDto> CreatePokemonAsync(PokemonDto pokemon);
        Task<bool> DeletePokemonAsync(PokemonDto pokemon);
        Task<bool> UpdatePokemonAsync(PokemonDto pokemon);
    }
}

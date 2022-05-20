using PokemonWiki.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokemonWiki.Core.Contracts.Services
{
    public interface IPokemonDataService
    {
        Task<IEnumerable<PokemonData>> GetPokemonDataAsync();
    }
}

using PokemonWiki.Core.Constants;
using PokemonWiki.Core.Constants.Contracts;
using PokemonWiki.Core.DTOs;
using PokemonWiki.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PokemonWiki.Core.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;
        public PokemonService()
        {
            _httpClient = new HttpClient() { BaseAddress = new System.Uri(BaseAddress.DataApi) };
        }

        public async Task<IEnumerable<PokemonDto>> GetPokemonsAsync()
        {
            var items = new List<PokemonDto>();
            HttpResponseMessage response = await _httpClient.GetAsync("pokemon?includeAttacks=true");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                items = await Json.ToObjectAsync<List<PokemonDto>>(content);
            }
            return items;
        }

        public async Task<PokemonDto> CreatePokemonAsync(PokemonDto pokemon)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"pokemon", pokemon);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<PokemonDto>();
        }

        public async Task<bool> DeletePokemonAsync(PokemonDto pokemon)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"pokemon/{pokemon.PokemonId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdatePokemonAsync(PokemonDto pokemon)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"pokemon/{pokemon.PokemonId}", pokemon);
            //response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }
    }
}

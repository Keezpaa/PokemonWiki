using CommunityToolkit.Mvvm.ComponentModel;
using PokemonWiki.Contracts.ViewModels;
using PokemonWiki.Core.Contracts.Services;
using PokemonWiki.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonWiki.ViewModels
{
    public class PokemonGalleryDetailViewModel : ObservableRecipient, INavigationAware
    {
        private readonly IPokemonDataService _pokemonDataService;
        private PokemonData _item;

        public PokemonData Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        public PokemonGalleryDetailViewModel(IPokemonDataService pokemonDataService)
        {
            _pokemonDataService = pokemonDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            if (parameter is long pokemonID)
            {
                var data = await _pokemonDataService.GetPokemonDataAsync();
                Item = data.First(i => i.PokemonID == pokemonID);
            }
        }

        public void OnNavigatedFrom()
        {
        }
    }
}
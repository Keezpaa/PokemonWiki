using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokemonWiki.Contracts.Services;
using PokemonWiki.Contracts.ViewModels;
using PokemonWiki.Core.Contracts.Services;
using PokemonWiki.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokemonWiki.ViewModels
{
    public class PokemonGalleryViewModel : ObservableRecipient, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IPokemonDataService _pokemonDataService;
        private ICommand _itemClickCommand;

        public ICommand ItemClickCommand => _itemClickCommand ??= new RelayCommand<PokemonData>(OnItemClick);

        public ObservableCollection<PokemonData> Source { get; } = new ObservableCollection<PokemonData>();

        public PokemonGalleryViewModel(INavigationService navigationService, IPokemonDataService pokemonDataService)
        {
            _navigationService = navigationService;
            _pokemonDataService = pokemonDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            Source.Clear();

            // Replace this with your actual data
            var data = await _pokemonDataService.GetPokemonDataAsync();
            foreach (var item in data)
            {
                Source.Add(item);
            }
        }

        public void OnNavigatedFrom()
        {
        }

        private void OnItemClick(PokemonData clickedItem)
        {
            if (clickedItem != null)
            {
                _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
                _navigationService.NavigateTo(typeof(PokemonGalleryDetailViewModel).FullName, clickedItem.PokemonID);
            }
        }
    }
}
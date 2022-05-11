﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using PokemonWiki.Contracts.Services;
using PokemonWiki.Contracts.ViewModels;
using PokemonWiki.Core.Constants.Contracts;
using PokemonWiki.Core.DTOs;
using PokemonWiki.DataAccess.Models;
using PokemonWiki.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokemonWiki.ViewModels
{
    public class PokemonsViewModel : ObservableRecipient, INavigationAware
    {
        private readonly IPokemonService _pokemonService;
        private readonly INavigationService _navigationService;

        public PokemonsViewModel(IPokemonService pokemonService, INavigationService navigationService)
        {
            _pokemonService = pokemonService;
            _navigationService = navigationService;
        }

        public PokemonDetailViewModel _selectedPokemon;

        public PokemonDetailViewModel SelectedPokemon
        {
            get => _selectedPokemon;
            set => SetProperty(ref _selectedPokemon, value);
        }
        // Delete Pokemon
        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand<PokemonDetailViewModel>(async param =>
                    {
                        ContentDialog deleteDialog = new()
                        {
                            Title = "Delete pokemon permanently?",
                            Content = "If you delete this pokemon, you won't be able to recover it. Do you want to delete it?",
                            PrimaryButtonText = "Delete",
                            CloseButtonText = "Cancel",
                            DefaultButton = ContentDialogButton.Close,
                            XamlRoot = _navigationService.Frame.XamlRoot
                        };

                        ContentDialogResult result = await deleteDialog.ShowAsync();

                        if (result == ContentDialogResult.Primary)
                        {
                            if (await _pokemonService.DeletePokemonAsync((PokemonDto)param))
                            {
                                _ = Pokemon.Remove(param);
                            }
                        }
                    }, param => param != null);
                }

                return _deleteCommand;
            }
        }
        // Update Pokemon
        private ICommand _updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                // if private ICommand is null
                if (_updateCommand == null)
                {
                    // 
                    _updateCommand = new RelayCommand<PokemonDetailViewModel>(async param =>
                    {
                        PokemonDetailViewModel newPokemon = new() { PokemonImage = "Unknown.jpg" };
                        PokemonPage page = new(newPokemon);

                        ContentDialog updateDialog = new()
                        {
                            Title = "Update pokemon",
                            Content = page,
                            PrimaryButtonText = "Update",
                            IsPrimaryButtonEnabled = false,
                            CloseButtonText = "Cancel",

                            DefaultButton = ContentDialogButton.Close,
                            XamlRoot = _navigationService.Frame.XamlRoot
                        };
                        // enables the primaryButton (UpdateButton) if the newCharacter doesn't have errors or missing required info
                        newPokemon.PropertyChanged += (sender, e) => updateDialog.IsPrimaryButtonEnabled = !newPokemon.HasErrors;

                        // contentDialogResult is an enum. result will be primary (1) if user clicks the primaryButton (UpdateButton)
                        ContentDialogResult result = await updateDialog.ShowAsync();

                        // if the primary button in contentdialog is tapped
                        if (result == ContentDialogResult.Primary)
                        {
                            // returns true if    , returns false if not
                            if (await _pokemonService.DeletePokemonAsync((PokemonDto)param))
                            {
                                _ = Pokemon.Remove(param);
                            }
                            Pokemon.Add(param);
                        }
                    }, param => param != null);
                }

                return _updateCommand;
            }
        }
        // Add Pokemon
        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(async () =>
                    {
                        PokemonDetailViewModel newPokemon = new() { PokemonImage = "Unknown.jpg" };
                        PokemonPage page = new(newPokemon);

                        ContentDialog dialog = new()
                        {
                            Title = "Add new pokemon",
                            Content = page,
                            PrimaryButtonText = "Add",
                            IsPrimaryButtonEnabled = false,
                            CloseButtonText = "Cancel",
                            DefaultButton = ContentDialogButton.Primary,
                            XamlRoot = _navigationService.Frame.XamlRoot
                        };

                        newPokemon.PropertyChanged += (sender, e) => dialog.IsPrimaryButtonEnabled = !newPokemon.HasErrors;

                        ContentDialogResult result = await dialog.ShowAsync();

                        if (result == ContentDialogResult.Primary)
                        {
                            var pokemonDto = await _pokemonService.CreatePokemonAsync((PokemonDto)newPokemon);
                            PokemonDetailViewModel pokemon = new(pokemonDto);

                            Pokemon.Add(pokemon);
                            SelectedPokemon = pokemon;
                        }
                    });
                }

                return _addCommand;
            }
        }
        public ObservableCollection<PokemonDetailViewModel> Pokemon { get; private set; } = new();
        public async void OnNavigatedTo(object parameter)
        {
            Pokemon.Clear();

            var pokemonDtos = await _pokemonService.GetPokemonsAsync();
            foreach (var pokemonDto in pokemonDtos)
            {
                Pokemon.Add(new PokemonDetailViewModel(pokemonDto));
            }

        }
        public void OnNavigatedFrom() { }

        public void EnsureItemSelected()
        {
            if (SelectedPokemon == null && Pokemon.Count > 0)
            {
                SelectedPokemon = Pokemon.First();
            }
        }
    }
}

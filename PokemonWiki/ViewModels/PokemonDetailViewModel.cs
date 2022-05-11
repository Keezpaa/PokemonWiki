using CommunityToolkit.Mvvm.ComponentModel;
using PokemonWiki.Core.Constants;
using PokemonWiki.Core.DTOs;
using PokemonWiki.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonWiki.ViewModels
{
    public class PokemonDetailViewModel : ObservableValidator
    {

        
        public PokemonDetailViewModel()
        {
            _pokemonDto = new PokemonDto();
            ValidateAllProperties();
            _errors.AddRange(GetErrors());
        }

        public PokemonDetailViewModel(PokemonDto pokemonDto)
        {
            _pokemonDto = pokemonDto;
            ValidateAllProperties();
            _errors.AddRange(GetErrors());
        }

        public static explicit operator PokemonDto(PokemonDetailViewModel p) => new()
        {
            PokemonId = p.PokemonId,
            Name = p.Name,
            Evolution = p.Evolution,
            PokemonType = p.PokemonType,
            Region = p.Region,
            Description = p.Description,
            PokemonImage = p.PokemonImage,
            Attacks = p.Attacks
        };

        private readonly PokemonDto _pokemonDto;
        private readonly List<ValidationResult> _errors = new();

        public string Errors => string.Join(Environment.NewLine, from ValidationResult e in _errors select e.ErrorMessage);
        public new bool HasErrors => Errors.Length > 0;

        public string PokemonImageFullPath => $"{BaseAddress.ImageApi}/{PokemonImage}";

        public int PokemonId
        {
            get => _pokemonDto.PokemonId;
            set => SetProperty(_pokemonDto.PokemonId, value, _pokemonDto, (_pokemonDto, id) => _pokemonDto.PokemonId = value);
        }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name should be longer than one character")]
        public string Name
        {
            get => _pokemonDto.Name;
            set
            {
                _ = _errors.RemoveAll(v => v.MemberNames.Contains(nameof(Name)));
                _ = TrySetProperty(_pokemonDto.Name, value, (name) => _pokemonDto.Name = name, out IReadOnlyCollection<ValidationResult> errors);

                _errors.AddRange(errors);
                OnPropertyChanged(nameof(Errors));
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        public string Evolution
        {
            get => _pokemonDto.Evolution;
            set => SetProperty(_pokemonDto.Evolution, value, (evolution) => _pokemonDto.Evolution = evolution);
        }

        [Required(ErrorMessage = "Pokemontype is required")]
        [MinLength(2, ErrorMessage = "Pokemontype should be longer than one character")]
        public string PokemonType
        {
            get => _pokemonDto.PokemonType;
            set
            {
                _ = _errors.RemoveAll(v => v.MemberNames.Contains(nameof(PokemonType)));
                _ = TrySetProperty(_pokemonDto.PokemonType, value, (type) => _pokemonDto.PokemonType = type, out IReadOnlyCollection<ValidationResult> errors);

                _errors.AddRange(errors);
                OnPropertyChanged(nameof(Errors));
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        public Regions Region 
        {
            get => _pokemonDto.Region;
            set => SetProperty(_pokemonDto.Region, value, (region) => _pokemonDto.Region = region);
        }

        public string Description
        {
            get => _pokemonDto.Description;
            set => SetProperty(_pokemonDto.Description, value, (description) => _pokemonDto.Description = description);
        }

        public string PokemonImage
        {
            get => _pokemonDto.PokemonImage;
            set => SetProperty(_pokemonDto.PokemonImage, value, (pokemonImage) => _pokemonDto.PokemonImage = pokemonImage);
        }

        public List<AttackDto> Attacks
        {
            get => _pokemonDto.Attacks;
            set => SetProperty(_pokemonDto.Attacks, value, (attacks) => _pokemonDto.Attacks = attacks);
        }
    }
}

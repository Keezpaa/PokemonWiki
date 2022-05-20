using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonWiki.Core.DTOs
{
    public class PokemonData
    {
        public long PokemonID { get; set; }

        public string BelongsToTrainer { get; set; }

        public string PokemonName { get; set; }

        public string Type { get; set; }

        public string Region { get; set; }
        public string Attacks { get; set; }

        public string PokemonImage { get; set; }
        public string ShinyPokemonImage { get; set; }
        public string PokemonBulbaDescription { get; set; }
        public string PokemonGoDescription { get; set; }

        public ICollection<PokemonAttack> PokemonDetails { get; set; }

        public override string ToString()
        {
            return $"{PokemonName} {Attacks}";
        }

        public string ShortDescription => $"Pokemon ID: {PokemonID}";
    }
}

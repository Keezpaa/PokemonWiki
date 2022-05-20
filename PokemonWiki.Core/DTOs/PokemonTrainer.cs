using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonWiki.Core.DTOs
{
    public class PokemonTrainer
    {
        public string TrainerID { get; set; }

        public string TrainerName { get; set; }
        public string Gender { get; set; }
        
        public string EyeColor { get; set; }

        public string Rivals { get; set; }

        public string FirstApperance { get; set; }

        public string Hometown { get; set; }

        public string Region { get; set; }

        public string Age { get; set; }

        public string TrainerClass { get; set; }
        public char Symbol => (char)SymbolCode;
        public int SymbolCode { get; set; }
        public string SymbolName { get; set; }

        public ICollection<PokemonData> Pokemons { get; set; }
    }
}

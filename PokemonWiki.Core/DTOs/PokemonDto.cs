using PokemonWiki.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonWiki.Core.DTOs
{
    public class PokemonDto
    {
        public int PokemonId { get; set; }
        public string Name { get; set; }
        public string Evolution { get; set; }
        public string PokemonType { get; set; }
        public string Description { get; set; }
        public Regions Region { get; set; }
        public string PokemonImage { get; set; }

        public List<AttackDto> Attacks { get; set; }
    }
}

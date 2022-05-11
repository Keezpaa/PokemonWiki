using PokemonWiki.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonWiki.DataAccess.Models
{
    public class Pokemon
    {
        public int PokemonId { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        public string Evolution { get; set; }
        public string PokemonType { get; set; }
        public string Description { get; set; }
        public Regions Region { get; set; }
        public string PokemonImage { get; set; }

        public List<Attack> Attacks { get; set; }  
    }
}

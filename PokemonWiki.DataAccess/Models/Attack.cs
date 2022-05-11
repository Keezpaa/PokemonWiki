using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonWiki.DataAccess.Models
{
    public class Attack
    {
        public int AttackId { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        public List<Pokemon> Pokemon { get; set; }
    }
}

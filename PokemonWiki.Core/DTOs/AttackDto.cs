using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonWiki.Core.DTOs
{
    public class AttackDto
    {
        public int AttackId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

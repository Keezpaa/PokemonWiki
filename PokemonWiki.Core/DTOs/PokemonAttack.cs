using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonWiki.Core.DTOs
{
    public class PokemonAttack
    {
        public long AttackID { get; set; }

        public string AttackName { get; set; }

        public double Damage { get; set; }
        public string AttackType { get; set; }

        public string StrongAgainst { get; set; }

        public string Weakness { get; set; }

        public string ShortDescription => $"Product ID: {AttackID} - {AttackName}";
    }
}

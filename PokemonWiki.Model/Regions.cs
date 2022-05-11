using System;

namespace PokemonWiki.Model
{
    [Flags]
    public enum Regions
    {
        Unknown = 0b_0000_0000,  // 0
        Kanto = 0b_0000_0001,  // 1
        Johto = 0b_0000_0010,  // 2
        Hoenn = 0b_0000_0011,  // 3
        Sinnoh = 0b_0000_0100,  // 4
        Unova = 0b_0000_0101,  // 5
        Kalos = 0b_0000_0110,  // 6
        Alola = 0b_0000_0111,  // 7
        Galar = 0b_0000_1000,  // 8
    }
}

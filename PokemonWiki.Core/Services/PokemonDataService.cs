using PokemonWiki.Core.Contracts.Services;
using PokemonWiki.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonWiki.Core.Services
{
    public class PokemonDataService : IPokemonDataService
    {

    
    private List<PokemonData> _allOrders;

    public PokemonDataService()
    {
    }

    private static IEnumerable<PokemonData> AllOrders()
    {
        // The following is order summary data
        var companies = AllCompanies();
        return companies.SelectMany(c => c.Pokemons);
    }

    private static IEnumerable<PokemonTrainer> AllCompanies()
    {
        return new List<PokemonTrainer>()
            {
                new PokemonTrainer()
                {
                    TrainerID = "Pokemonseries: Red and Blue",
                    TrainerName = "Ash Ketchum",
                    Age = "10",
                    Gender = "Male",
                    EyeColor = "Brown",
                    Rivals = "Team Rocket",
                    FirstApperance = "Pokémon Red and Blue",
                    Hometown = "Pallet Town",
                    Region = "Kanto",
                    SymbolCode = 57620,
                    SymbolName = "Camera",
                    TrainerClass = "Trainer, Champion",
                    Pokemons = new List<PokemonData>()
                    {
                        new PokemonData()
                        {
                            PokemonID = 25, // Number in the official Pokédex
                            BelongsToTrainer = "Ash Ketchum",
                            PokemonName = "Pikachu",
                            Type = "Electric",
                            Attacks = "Brick Break, Wild Charge, Grass Knot",
                            PokemonBulbaDescription = "Pikachu (Japanese: ピカチュウ Pikachu) is an Electric-type Pokémon introduced in Generation I. It evolves from Pichu when leveled up with high friendship and evolves into Raichu when exposed to a Thunder Stone. In Alola, Pikachu will evolve into Alolan Raichu when exposed to a Thunder Stone. Pikachu has a Gigantamax form. Pikachu with the Gigantamax Factor cannot evolve. In Pokémon Yellow, the starter Pikachu will refuse to evolve into Raichu unless it is traded and evolved on another save file. In Pokémon: Let's Go, Pikachu!, the player's starter Pikachu also will not evolve, but cannot be traded to become a Raichu. Pikachu is popularly known as the mascot of the Pokémon franchise and one of Nintendo's major mascots. It is also the game mascot and starter Pokémon of Pokémon Yellow and Let's Go, Pikachu!. It has made numerous appearances on the boxes of spin-off titles. Pikachu is also the starter Pokémon in Pokémon Rumble Blast and Pokémon Rumble World. ",
                            PokemonGoDescription ="Whenever Pikachu comes across something new, it blasts it with a jolt of electricity. If you come across a blackened berry, it's evidence that this Pokémon mistook the intensity of its charge.",
                            PokemonImage = "/Assets/pikachu.png",
                            ShinyPokemonImage ="/Assets/shinypikachu.png",
                            Region = "Kanto",
                            PokemonDetails = new List<PokemonAttack>()
                            {
                                new PokemonAttack()
                                {
                                    AttackID = 1,
                                    AttackName = "Grass Knot",
                                    AttackType = "Grass",
                                    Damage = 70,
                                    StrongAgainst = "Ground, Rock, Water",
                                    Weakness = "Bug, Fire, Flying, Ice, Poison"
                                },
                                new PokemonAttack()
                                {
                                    AttackID = 2,
                                    AttackName = "Wild Charge",
                                    AttackType = "Electric",
                                    Damage = 70,
                                    StrongAgainst = "Flying, Water",
                                    Weakness = "Ground"
                                },
                                new PokemonAttack()
                                {
                                    AttackID = 3,
                                    AttackName = "Brick Brake",
                                    AttackType = "Fighting",
                                    Damage = 45,
                                    StrongAgainst = "Dark, Ice, Normal, Rock, Steel",
                                    Weakness = "Fairy, Flying, Psychic"
                                }
                            }
                        },
                        new PokemonData()
                        {
                            PokemonID = 7, // Number in the official Pokédex
                            BelongsToTrainer = "Ash Ketchum",
                            PokemonName = "Squirtle",
                            Type = "Water",
                            PokemonBulbaDescription = "Squirtle (Japanese: ゼニガメ Zenigame) is a Water-type Pokémon introduced in Generation I. It evolves into Wartortle starting at level 16, which evolves into Blastoise starting at level 36. Along with Bulbasaur and Charmander, Squirtle is one of three starter Pokémon of Kanto available at the beginning of Pokémon Red, Green, Blue, FireRed, and LeafGreen. ",
                            PokemonGoDescription ="Squirtle's shell is not merely used for protection. The shell's rounded shape and the grooves on its surface help minimize resistance in water, enabling this Pokémon to swim at high speeds",
                            PokemonImage = "/Assets/squirtle.png",
                            ShinyPokemonImage ="/Assets/shinysquirtle.png",
                            Attacks = "Aqua Jet, WaterPulse",
                            Region = "Kanto",
                            PokemonDetails = new List<PokemonAttack>()
                            {
                                new PokemonAttack()
                                {
                                    AttackID = 4,
                                    AttackName = "Aqua Jet",
                                    AttackType = "Water",
                                    Damage = 45,
                                    StrongAgainst= "Fire, Ground, Rock, Electric",
                                    Weakness = "Grass"
                                },
                                new PokemonAttack()
                                {
                                    AttackID = 5,
                                    AttackName = "Water Pulse",
                                    AttackType = "Water",
                                    Damage = 70,
                                    StrongAgainst = "Fire, Ground, Rock, Electric",
                                    Weakness = "Grass"
                                }
                            }
                        },
                        new PokemonData()
                        {
                            PokemonID = 1, // Number in the official Pokédex
                            BelongsToTrainer = "Ash Ketchum",
                            PokemonName = "Bulbasaur",
                            PokemonBulbaDescription = "Bulbasaur (Japanese: フシギダネ Fushigidane) is a dual-type Grass/Poison Pokémon introduced in Generation I. It evolves into Ivysaur starting at level 16, which evolves into Venusaur starting at level 32. Along with Charmander and Squirtle, Bulbasaur is one of three starter Pokémon of Kanto available at the beginning of Pokémon Red, Green, Blue, FireRed, and LeafGreen. ",
                            PokemonGoDescription ="Bulbasaur can be seen napping in bright sunlight. There is a seed on its back. By soaking up the sun's rays, the seed grows progressively larger.",
                            PokemonImage = "/Assets/bulbasaur.png",
                            ShinyPokemonImage ="/Assets/shinybulbasaur.png",
                            Type = "Grass/Poison",
                            Attacks = "Seed Bomb, Sludge Bomb",
                            Region = "Kanto",
                            PokemonDetails = new List<PokemonAttack>()
                            {
                                new PokemonAttack()
                                {
                                    AttackID = 6,
                                    AttackName = "Seed Bomb",
                                    AttackType = "Grass",
                                    Damage = 55,
                                    StrongAgainst = "Ground, Rock, Water",
                                    Weakness = "Bug, Fire, Flying, Ice, Poison"
                                },
                                new PokemonAttack()
                                {
                                    AttackID = 7,
                                    AttackName = "Sludge Bomb",
                                    AttackType = "Poison",
                                    Damage = 15,
                                    StrongAgainst = "Fairy, Grass",
                                    Weakness = "Ground, Psychic"
                                }
                            }
                        }
                    }
                },
                new PokemonTrainer()
                {
                    TrainerID = "Pokemonseries: Red and Blue",
                    TrainerName = "Ash Ketchum",
                    Age = "10",
                    Gender = "Male",
                    EyeColor = "Brown",
                    Rivals = "Team Rocket",
                    FirstApperance = "Pokémon Red and Blue",
                    Hometown = "Pallet Town",
                    Region = "Kanto",
                    SymbolCode = 57620,
                    SymbolName = "Camera",
                    TrainerClass = "Trainer, Champion",
                    Pokemons = new List<PokemonData>()
                    {
                        new PokemonData()
                        {
                            PokemonID = 130, // Number in the Pokédex
                            BelongsToTrainer = "Ash Ketchum",
                            PokemonName = "Gyarados",
                            Type = "Water/Flying",
                            PokemonBulbaDescription = "Gyarados (Japanese: ギャラドス Gyarados) is a dual-type Water/Flying Pokémon introduced in Generation I. It evolves from Magikarp starting at level 20. Gyarados can Mega Evolve into Mega Gyarados using the Gyaradosite.",
                            PokemonGoDescription ="When Magikarp evolves into Gyarados, its brain cells undergo a structural transformation. It is said that this transformation is to blame for this Pokémon's wildly violent nature.",
                            PokemonImage = "/Assets/gyarados.png",
                            ShinyPokemonImage ="/Assets/shinygyarados.png",
                            Attacks = "Twister, Dragon Pulse, Crunch",
                            Region = "Kanto",
                            PokemonDetails = new List<PokemonAttack>()
                            {
                                new PokemonAttack()
                                {
                                    AttackID = 8,
                                    AttackName = "Twister",
                                    AttackType = "Dragon",
                                    Damage = 45,
                                    StrongAgainst = "Dragon",
                                    Weakness = "Dragon, Fairy, Ice"
                                },
                                new PokemonAttack()
                                {
                                    AttackID = 9,
                                    AttackName = "Dragon Pulse",
                                    AttackType = "Dragon",
                                    Damage = 90,
                                    StrongAgainst = "Dragon",
                                    Weakness = "Dragon, Fairy, Ice"
                                },
                                new PokemonAttack()
                                {
                                    AttackID = 10,
                                    AttackName = "Crunch",
                                    AttackType = "Dark",
                                    Damage = 70,
                                    StrongAgainst = "Ghost, Psychic",
                                    Weakness = "Bug, Fairy, Fighting"
                                }
                            }
                        },
                        new PokemonData()
                        {
                            PokemonID = 150, // Number in the Pokédex
                            BelongsToTrainer = "Ash Ketchum",
                            PokemonName = "Mewtwo",
                            Type = "Psychic",
                            PokemonBulbaDescription = "Mewtwo (Japanese: ミュウツー Mewtwo) is a Psychic-type Legendary Pokémon introduced in Generation I. While it is not known to evolve into or from any other Pokémon, Mewtwo can Mega Evolve into two different forms: Mega Mewtwo X using Mewtwonite X. Mega Mewtwo Y using Mewtwonite Y. It is a member of the Mew duo along with Mew.",
                            PokemonGoDescription = "Mewtwo is a Pokémon that was created by genetic manipulation. However, even though the scientific power of humans created this Pokémon's body, they failed to endow Mewtwo with a compassionate heart.",
                            PokemonImage = "/Assets/mewtwoPic.png",
                            ShinyPokemonImage ="/Assets/shinymewtwo.png",
                            Attacks = "Psychic, Psystrike",
                            Region = "Kanto",
                            PokemonDetails = new List<PokemonAttack>()
                            {
                                new PokemonAttack()
                                {
                                    AttackID = 11,
                                    AttackName = "Psychic",
                                    AttackType = "Psychic",
                                    Damage = 100,
                                    StrongAgainst = "Fighting, Poison",
                                    Weakness = "Bug, Dark, Ghost"
                                },
                                new PokemonAttack()
                                {
                                    AttackID = 12,
                                    AttackName = "Psystrike",
                                    AttackType = "Psychic",
                                    Damage = 100,
                                    StrongAgainst = "Fighting, Poison",
                                    Weakness = "Bug, Dark, Ghost"
                                }
                            }
                        }
                    }
                },
                new PokemonTrainer()
                {
                    TrainerID = "Pokemonseries: Red and Blue",
                    TrainerName = "Ash Ketchum",
                    Age = "10",
                    Gender = "Male",
                    EyeColor = "Brown",
                    Rivals = "Team Rocket",
                    FirstApperance = "Pokémon Red and Blue",
                    Hometown = "Pallet Town",
                    Region = "Kanto",
                    SymbolCode = 57620,
                    SymbolName = "Camera",
                    TrainerClass = "Trainer, Champion",
                    Pokemons = new List<PokemonData>()
                    {
                        new PokemonData()
                        {
                            PokemonID = 282, // Number in the Pokédex
                            BelongsToTrainer = "Ash Ketchum",
                            PokemonName = "Gardevoir",
                            Type = "Psychic/Fairy",
                            Attacks = "Shadow Ball, Dazzling Gleam",
                            Region = "Hoenn",
                            PokemonBulbaDescription = "Gardevoir (Japanese: サーナイト Sirknight) is a dual-type Psychic/Fairy Pokémon introduced in Generation III. Prior to Generation VI, it was a pure Psychic-type Pokémon. It evolves from Kirlia starting at level 30. It is one of Ralts's final forms, the other being Gallade. Gardevoir can Mega Evolve into Mega Gardevoir using the Gardevoirite. ",
                            PokemonGoDescription ="Gardevoir has the ability to read the future. If it senses impending danger to its Trainer, this Pokémon is said to unleash its psychokinetic energy at full power.",
                            PokemonImage = "/Assets/gardevoir.png",
                            ShinyPokemonImage ="/Assets/shinygardevoir.png",
                            PokemonDetails = new List<PokemonAttack>()
                            {
                                new PokemonAttack()
                                {
                                    AttackID = 13,
                                    AttackName = "Shadow Ball",
                                    AttackType = "Ghost",
                                    Damage = 100,
                                    StrongAgainst = "Ghost, Psychic",
                                    Weakness = "Dark, Ghost"
                                },
                                new PokemonAttack()
                                {
                                    AttackID = 14,
                                    AttackName = "Dazzling Gleam",
                                    AttackType = "Psychic",
                                    Damage = 100,
                                    StrongAgainst = "Fighting, Poison",
                                    Weakness = "Bug, Dark, Ghost"
                                }
                            }
                        },
                        new PokemonData()
                        {
                            PokemonID = 658, // Number in the Pokédex
                            BelongsToTrainer = "Ash Ketchum",
                            PokemonName = "Greninja",
                            Type = "Water/Dark",
                            Attacks = "Night Slash, Extrasensory",
                            Region = "Kalos",
                            PokemonBulbaDescription = "Greninja (Japanese: ゲッコウガ Gekkouga) is a dual-type Water/Dark Pokémon introduced in Generation VI. It evolves from Frogadier starting at level 36. It is the final form of Froakie. With the Battle Bond Ability, Greninja can transform into a special form known as Ash-Greninja. Greninja with the Ability Battle Bond cannot breed. ",
                            PokemonGoDescription ="It creates throwing stars out of compressed water. When it spins them and throws them at high speed, these stars can split metal in two.",
                            PokemonImage = "/Assets/greninja.png",
                            ShinyPokemonImage ="/Assets/shinygreninja.png",
                            PokemonDetails = new List<PokemonAttack>()
                            {
                                new PokemonAttack()
                                {
                                    AttackID = 15,
                                    AttackName = " Extrasensory",
                                    AttackType = "Psychic",
                                    Damage = 80,
                                    StrongAgainst = "Fighting, Poison",
                                    Weakness = "Bug, Dark, Ghost"
                                },
                                new PokemonAttack()
                                {
                                    AttackID = 16,
                                    AttackName = "Night Slash",
                                    AttackType = "Dark",
                                    Damage = 70,
                                    StrongAgainst = "Ghost, Psychic",
                                    Weakness = "Bug, Fairy, Fighting"
                                }
                            }
                        },
                        new PokemonData()
                        {
                            PokemonID = 487, // Number in the Pokédex
                            BelongsToTrainer = "Ash Ketchum",
                            PokemonName = "Giratina",
                            Type = "Ghost/Dragon",
                            Attacks = "Dragon Claw, Ancient Power",
                            Region = "Kanto",
                            PokemonBulbaDescription = "Giratina (Japanese: ギラティナ Giratina) is a dual-type Ghost/Dragon Legendary Pokémon introduced in Generation IV. While it is not known to evolve to or from any other Pokémon, Giratina has a second forme activated by giving Giratina a Griseous Orb to hold, or by using the Griseous Core on it. It will also transform while it is in its home, the Distortion World. Its original forme, Altered Forme, will then become Origin Forme. Giratina's Origin Forme was officially revealed in early February 2008. Giratina is the game mascot of Pokémon Platinum, appearing on the boxart in its Origin Forme. Along with Dialga and Palkia, it is a member of the creation trio of Sinnoh, representing antimatter. ",
                            PokemonGoDescription ="It was banished for its violence. It silently gazed upon the old world from the Distortion World.",
                            PokemonImage = "/Assets/giratina.png",
                            ShinyPokemonImage ="/Assets/shinygiratina.png",
                            PokemonDetails = new List<PokemonAttack>()
                            {
                                new PokemonAttack()
                                {
                                    AttackID = 17,
                                    AttackName = "Dragon Claw",
                                    AttackType = "Dragon",
                                    Damage = 50,
                                    StrongAgainst = "Dragon",
                                    Weakness = "Dragon, Fairy, Ice"
                                },
                                new PokemonAttack()
                                {
                                    AttackID = 18,
                                    AttackName = "Ancient Power",
                                    AttackType = "Rock",
                                    Damage = 70,
                                    StrongAgainst = "Bug, Fire, Flying, Ice",
                                    Weakness = "Fighting, Grass, Ground, Steel, Water"
                                }
                            }
                        }
                    }
                }
            };
    }

    public async Task<IEnumerable<PokemonData>> GetPokemonDataAsync()
    {
        if (_allOrders == null)
        {
            _allOrders = new List<PokemonData>(AllOrders());
        }

        await Task.CompletedTask;
        return _allOrders;
    }
}
}

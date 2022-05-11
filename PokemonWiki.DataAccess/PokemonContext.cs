using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonWiki.DataAccess.Models;
using PokemonWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PokemonWiki.DataAccess
{
    public class PokemonContext : DbContext
    {
        public PokemonContext() { }
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "Donau.hiof.no",
                InitialCatalog = "kasperi",
                UserID = "kasperi",
                Password = "8eREM7MAYf"
            };
            _ = optionsBuilder.UseSqlServer(builder.ConnectionString.ToString());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AttackEntityTypeConfiguration().Configure(modelBuilder.Entity<Attack>());
            new PokemonEntityTypeConfiguration().Configure(modelBuilder.Entity<Pokemon>());
        }

        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Attack> Attacks { get; set; }
    }
    public class AttackEntityTypeConfiguration : IEntityTypeConfiguration<Attack>
    {
        public void Configure(EntityTypeBuilder<Attack> builder)
        {
            #region Seeding Attacks
            // Pikachu/Raichu
            builder.HasData(new Attack { AttackId = 1, Name = "Thunderbolt" });
            builder.HasData(new Attack { AttackId = 2, Name = "Discharge" });
            builder.HasData(new Attack { AttackId = 3, Name = "Grass Knot" });
            builder.HasData(new Attack { AttackId = 4, Name = "Brick Brake" });
            builder.HasData(new Attack { AttackId = 5, Name = "Focus Punch" });

            // Cyndaquil/Quilava/Typhlosion
            builder.HasData(new Attack { AttackId = 6, Name = "Overheat" });
            builder.HasData(new Attack { AttackId = 7, Name = "Fire Blast" });
            builder.HasData(new Attack { AttackId = 8, Name = "Flamethrower" });
            builder.HasData(new Attack { AttackId = 9, Name = "Dig" });
            builder.HasData(new Attack { AttackId = 10, Name = "Aerial Ace" });

            // Beldum/Metang/Metagross
            builder.HasData(new Attack { AttackId = 11, Name = "Explosion" });
            builder.HasData(new Attack { AttackId = 12, Name = "Giga Impact" });
            builder.HasData(new Attack { AttackId = 13, Name = "Earthquake" });
            builder.HasData(new Attack { AttackId = 14, Name = "Sludge Bomb" });
            builder.HasData(new Attack { AttackId = 15, Name = "Psychic" });

            // Gible/Gabite/Garchomp
            builder.HasData(new Attack { AttackId = 16, Name = "Stone Edge" });
            builder.HasData(new Attack { AttackId = 17, Name = "Fire Blast" });
            builder.HasData(new Attack { AttackId = 18, Name = "Dragon Pulse" });
            builder.HasData(new Attack { AttackId = 19, Name = "Surf" });
            builder.HasData(new Attack { AttackId = 20, Name = "Rock Climb" });

            // Sandile/Krokorok/Krookodile
            builder.HasData(new Attack { AttackId = 21, Name = "Retaliate" });
            builder.HasData(new Attack { AttackId = 22, Name = "Shadow Claw" });
            builder.HasData(new Attack { AttackId = 23, Name = "Low Sweep" });
            builder.HasData(new Attack { AttackId = 24, Name = "Fire Fang" });
            builder.HasData(new Attack { AttackId = 25, Name = "Bulldoze" });

            // Fletchling/Fletchinder/Talonflame
            builder.HasData(new Attack { AttackId = 26, Name = "Fly" });
            builder.HasData(new Attack { AttackId = 27, Name = "U-turn" });
            builder.HasData(new Attack { AttackId = 28, Name = "Brave Bird" });
            builder.HasData(new Attack { AttackId = 29, Name = "Flame Charge" });
            builder.HasData(new Attack { AttackId = 30, Name = "Acrobatics" });

            // Fomantis/Lurantis
            builder.HasData(new Attack { AttackId = 31, Name = "Solar Blade" });
            builder.HasData(new Attack { AttackId = 32, Name = "Petal Blizzard" });
            builder.HasData(new Attack { AttackId = 33, Name = "X-Scissor" });
            builder.HasData(new Attack { AttackId = 34, Name = "Leaf Blade" });
            builder.HasData(new Attack { AttackId = 35, Name = "Slash" });

            // Mr. Rime
            builder.HasData(new Attack { AttackId = 36, Name = "Hyper Beam" });
            builder.HasData(new Attack { AttackId = 37, Name = "Psybeam" });
            builder.HasData(new Attack { AttackId = 38, Name = "Solar Beam" });
            builder.HasData(new Attack { AttackId = 39, Name = "Mega Kick" });
            builder.HasData(new Attack { AttackId = 40, Name = "Stomping Tantrum" });

            // Meltan/Melmetal
            builder.HasData(new Attack { AttackId = 41, Name = "Superpower" });
            builder.HasData(new Attack { AttackId = 42, Name = "Dynamic Punch" });
            builder.HasData(new Attack { AttackId = 43, Name = "Flash Cannon" });
            builder.HasData(new Attack { AttackId = 44, Name = "Double Iron Bash" });
            builder.HasData(new Attack { AttackId = 45, Name = "Self-Destruct" });



            #endregion
        }

    }
    public class PokemonEntityTypeConfiguration : IEntityTypeConfiguration<Pokemon>
    {
        public void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            // En pokemon til hver region
            #region Seeding Pokemon
            var description = "Pikachu (Japanese: ピカチュウ Pikachu) is an Electric-type Pokémon introduced in Generation I. It evolves from Pichu when leveled up with high friendship and evolves into Raichu when exposed to a Thunder Stone. Pikachu is popularly known as the mascot of the Pokémon franchise and one of Nintendo's major mascots.";
            builder.HasData(new Pokemon { PokemonId = 1, Name = "Pikachu", Evolution = "Raichu", PokemonType = "Electric", Description = description, Region = Regions.Kanto, PokemonImage = "pikachu.png", });
            description = "Cyndaquil (Japanese: ヒノアラシ Hinoarashi) is a Fire-type Pokémon introduced in Generation II. It evolves into Quilava starting at level 14 (Generations II to VII, Brilliant Diamond and Shining Pearl) or level 17 (Legends: Arceus), which evolves into Typhlosion starting at level 36. Along with Chikorita and Totodile, Cyndaquil is one of the three starter Pokémon of Johto available at the beginning of Pokémon Gold, Silver, Crystal, HeartGold, and SoulSilver. It also acts as one of the three starters for the Hisui region in Legends: Arceus alongside Rowlet and Oshawott.";
            builder.HasData(new Pokemon { PokemonId = 2, Name = "Cyndaquil", Evolution = "Quilava -> Typhlosion", PokemonType = "Fire", Description = description, Region = Regions.Johto, PokemonImage = "cyndaquil.png", });
            description = "Beldum (Japanese: ダンバル Dumbber) is a dual-type Steel/Psychic Pokémon introduced in Generation III. It evolves into Metang starting at level 20, which evolves into Metagross starting at level 45.";
            builder.HasData(new Pokemon { PokemonId = 3, Name = "Beldum", Evolution = "Metang -> Metagross", PokemonType = "Steel/Psychic", Description = description, Region = Regions.Hoenn, PokemonImage = "beldum.png", });
            description = "Gible (Japanese: フカマル Fukamaru) is a dual-type Dragon/Ground Pokémon introduced in Generation IV. It evolves into Gabite starting at level 24, which evolves into Garchomp starting at level 48.";
            builder.HasData(new Pokemon { PokemonId = 4, Name = "Gible", Evolution = "Gabite -> Garchomp", PokemonType = "Dragon/Ground", Description = description, Region = Regions.Sinnoh, PokemonImage = "gible.png", });
            description = "Sandile (Japanese: メグロコ Meguroco) is a dual-type Ground/Dark Pokémon introduced in Generation V. It evolves into Krokorok starting at level 29, which evolves into Krookodile starting at level 40.";
            builder.HasData(new Pokemon { PokemonId = 5, Name = "Sandile", Evolution = "Krokorok -> Krookodile", PokemonType = "Ground/Dark", Description = description, Region = Regions.Unova, PokemonImage = "sandile.png", });
            description = "Fletchling (Japanese: ヤヤコマ Yayakoma) is a dual-type Normal/Flying Pokémon introduced in Generation VI. It evolves into Fletchinder starting at level 17, which evolves into Talonflame starting at level 35.";
            builder.HasData(new Pokemon { PokemonId = 6, Name = "Fletchling", Evolution = "Fletchinder -> Talonflame", PokemonType = "Normal/Flying", Description = description, Region = Regions.Kalos, PokemonImage = "fletchling.png", });
            description = "Fomantis (Japanese: カリキリ Karikiri) is a Grass-type Pokémon introduced in Generation VII. It evolves into Lurantis when leveled up in the day starting at level 34.";
            builder.HasData(new Pokemon { PokemonId = 7, Name = "Fomantis", Evolution = "Lurantis", PokemonType = "Grass", Description = description, Region = Regions.Alola, PokemonImage = "fomantis.png", });
            description = "Mr. Rime (Japanese: バリコオル Barrikohru) is a dual-type Ice/Psychic Pokémon introduced in Generation VIII. It evolves from Galarian Mr.Mime starting at level 42.It is the final form of Mime Jr. in the Galar region.";
            builder.HasData(new Pokemon { PokemonId = 8, Name = "Mr. Rime", Evolution = "Mr.Mime <-", PokemonType = "Ice/Psychic", Description = description, Region = Regions.Galar, PokemonImage = "mrrime.png", });
            description = "Meltan (Japanese: メルタン Meltan) is a Steel-type Mythical Pokémon introduced in Generation VII in Pokémon: Let's Go, Pikachu! and Let's Go, Eevee!. In Pokémon GO, it evolves into Melmetal by using 400 Meltan Candy. It cannot be evolved in other games. Its appearance was first teased during the September Pokémon GO Community Day on September 22, 2018, and it was officially revealed on September 25, 2018.";
            builder.HasData(new Pokemon { PokemonId = 9, Name = "Meltan", Evolution = "Melmetal", PokemonType = "Steel", Description = description, Region = Regions.Unknown, PokemonImage = "meltan.png", });
            #endregion
            #region Pokemon attacks
            builder
                .HasMany(p => p.Attacks)
                .WithMany(a => a.Pokemon)
                .UsingEntity<Dictionary<string, object>>(
                    "PokemonAttack",
                    r => r.HasOne<Attack>().WithMany().HasForeignKey("AttacksAttackId"),
                    l => l.HasOne<Pokemon>().WithMany().HasForeignKey("PokemonPokemonId"),
                    je =>
                    {
                        je.HasKey("PokemonPokemonId", "AttacksAttackId");
                        je.HasData(
                        #region Pikachu powers
                            new { PokemonPokemonId = 1, AttacksAttackId = 1 },
                            new { PokemonPokemonId = 1, AttacksAttackId = 2 },
                            new { PokemonPokemonId = 1, AttacksAttackId = 3 },
                            new { PokemonPokemonId = 1, AttacksAttackId = 4 },
                            new { PokemonPokemonId = 1, AttacksAttackId = 5 },

                        #endregion
                        #region Cyndaquil powers
                            new { PokemonPokemonId = 2, AttacksAttackId = 6 },
                            new { PokemonPokemonId = 2, AttacksAttackId = 7 },
                            new { PokemonPokemonId = 2, AttacksAttackId = 8 },
                            new { PokemonPokemonId = 2, AttacksAttackId = 9 },
                            new { PokemonPokemonId = 2, AttacksAttackId = 10 },
                        #endregion
                        #region Beldum powers
                            new { PokemonPokemonId = 3, AttacksAttackId = 11 },
                            new { PokemonPokemonId = 3, AttacksAttackId = 12 },
                            new { PokemonPokemonId = 3, AttacksAttackId = 13 },
                            new { PokemonPokemonId = 3, AttacksAttackId = 14 },
                            new { PokemonPokemonId = 3, AttacksAttackId = 15 },
                        #endregion
                        #region Gible powers
                            new { PokemonPokemonId = 4, AttacksAttackId = 16 },
                            new { PokemonPokemonId = 4, AttacksAttackId = 17 },
                            new { PokemonPokemonId = 4, AttacksAttackId = 18 },
                            new { PokemonPokemonId = 4, AttacksAttackId = 19 },
                            new { PokemonPokemonId = 4, AttacksAttackId = 20 },
                    #endregion
                    #region Sandile powers
                    new { PokemonPokemonId = 5, AttacksAttackId = 21 },
                            new { PokemonPokemonId = 5, AttacksAttackId = 22 },
                            new { PokemonPokemonId = 5, AttacksAttackId = 23 },
                            new { PokemonPokemonId = 5, AttacksAttackId = 24 },
                            new { PokemonPokemonId = 5, AttacksAttackId = 25 },
                        #endregion
                        #region Fletchling powers
                            new { PokemonPokemonId = 6, AttacksAttackId = 26 },
                            new { PokemonPokemonId = 6, AttacksAttackId = 27 },
                            new { PokemonPokemonId = 6, AttacksAttackId = 28 },
                            new { PokemonPokemonId = 6, AttacksAttackId = 29 },
                            new { PokemonPokemonId = 6, AttacksAttackId = 30 },
                        #endregion
                        #region Fomantis powers
                            new { PokemonPokemonId = 7, AttacksAttackId = 31 },
                            new { PokemonPokemonId = 7, AttacksAttackId = 32 },
                            new { PokemonPokemonId = 7, AttacksAttackId = 33 },
                            new { PokemonPokemonId = 7, AttacksAttackId = 34 },
                            new { PokemonPokemonId = 7, AttacksAttackId = 35 },
                        #endregion
                        #region Mr. Rime powers
                            new { PokemonPokemonId = 8, AttacksAttackId = 36 },
                            new { PokemonPokemonId = 8, AttacksAttackId = 37 },
                            new { PokemonPokemonId = 8, AttacksAttackId = 38 },
                            new { PokemonPokemonId = 8, AttacksAttackId = 39 },
                            new { PokemonPokemonId = 8, AttacksAttackId = 40 },
                        #endregion
                        #region Meltan powers
                            new { PokemonPokemonId = 9, AttacksAttackId = 41 },
                            new { PokemonPokemonId = 9, AttacksAttackId = 42 },
                            new { PokemonPokemonId = 9, AttacksAttackId = 43 },
                            new { PokemonPokemonId = 9, AttacksAttackId = 44 },
                            new { PokemonPokemonId = 9, AttacksAttackId = 45 });
            #endregion
        });
            #endregion

        }

    }
}
   

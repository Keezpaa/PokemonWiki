using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonWiki.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attacks",
                columns: table => new
                {
                    AttackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attacks", x => x.AttackId);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    PokemonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Evolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PokemonType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<int>(type: "int", nullable: false),
                    PokemonImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.PokemonId);
                });

            migrationBuilder.CreateTable(
                name: "PokemonAttack",
                columns: table => new
                {
                    PokemonPokemonId = table.Column<int>(type: "int", nullable: false),
                    AttacksAttackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonAttack", x => new { x.PokemonPokemonId, x.AttacksAttackId });
                    table.ForeignKey(
                        name: "FK_PokemonAttack_Attacks_AttacksAttackId",
                        column: x => x.AttacksAttackId,
                        principalTable: "Attacks",
                        principalColumn: "AttackId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonAttack_Pokemon_PokemonPokemonId",
                        column: x => x.PokemonPokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "PokemonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Attacks",
                columns: new[] { "AttackId", "Name" },
                values: new object[,]
                {
                    { 1, "Thunderbolt" },
                    { 26, "Fly" },
                    { 28, "Brave Bird" },
                    { 29, "Flame Charge" },
                    { 30, "Acrobatics" },
                    { 31, "Solar Blade" },
                    { 32, "Petal Blizzard" },
                    { 33, "X-Scissor" },
                    { 34, "Leaf Blade" },
                    { 35, "Slash" },
                    { 36, "Hyper Beam" },
                    { 37, "Psybeam" },
                    { 38, "Solar Beam" },
                    { 39, "Mega Kick" },
                    { 40, "Stomping Tantrum" },
                    { 41, "Superpower" },
                    { 42, "Dynamic Punch" },
                    { 43, "Flash Cannon" },
                    { 44, "Double Iron Bash" },
                    { 45, "Self-Destruct" },
                    { 25, "Bulldoze" },
                    { 24, "Fire Fang" },
                    { 27, "U-turn" },
                    { 22, "Shadow Claw" },
                    { 2, "Discharge" },
                    { 3, "Grass Knot" },
                    { 4, "Brick Brake" },
                    { 5, "Focus Punch" },
                    { 6, "Overheat" },
                    { 7, "Fire Blast" },
                    { 23, "Low Sweep" },
                    { 9, "Dig" },
                    { 10, "Aerial Ace" },
                    { 11, "Explosion" },
                    { 8, "Flamethrower" },
                    { 13, "Earthquake" },
                    { 12, "Giga Impact" },
                    { 20, "Rock Climb" },
                    { 19, "Surf" },
                    { 18, "Dragon Pulse" },
                    { 21, "Retaliate" },
                    { 16, "Stone Edge" }
                });

            migrationBuilder.InsertData(
                table: "Attacks",
                columns: new[] { "AttackId", "Name" },
                values: new object[,]
                {
                    { 15, "Psychic" },
                    { 14, "Sludge Bomb" },
                    { 17, "Fire Blast" }
                });

            migrationBuilder.InsertData(
                table: "Pokemon",
                columns: new[] { "PokemonId", "Description", "Evolution", "Name", "PokemonImage", "PokemonType", "Region" },
                values: new object[,]
                {
                    { 8, "Mr. Rime (Japanese: バリコオル Barrikohru) is a dual-type Ice/Psychic Pokémon introduced in Generation VIII. It evolves from Galarian Mr.Mime starting at level 42.It is the final form of Mime Jr. in the Galar region.", "Mr.Mime <-", "Mr. Rime", "mrrime.png", "Ice/Psychic", 8 },
                    { 1, "Pikachu (Japanese: ピカチュウ Pikachu) is an Electric-type Pokémon introduced in Generation I. It evolves from Pichu when leveled up with high friendship and evolves into Raichu when exposed to a Thunder Stone. Pikachu is popularly known as the mascot of the Pokémon franchise and one of Nintendo's major mascots.", "Raichu", "Pikachu", "pikachu.png", "Electric", 1 },
                    { 2, "Cyndaquil (Japanese: ヒノアラシ Hinoarashi) is a Fire-type Pokémon introduced in Generation II. It evolves into Quilava starting at level 14 (Generations II to VII, Brilliant Diamond and Shining Pearl) or level 17 (Legends: Arceus), which evolves into Typhlosion starting at level 36. Along with Chikorita and Totodile, Cyndaquil is one of the three starter Pokémon of Johto available at the beginning of Pokémon Gold, Silver, Crystal, HeartGold, and SoulSilver. It also acts as one of the three starters for the Hisui region in Legends: Arceus alongside Rowlet and Oshawott.", "Quilava -> Typhlosion", "Cyndaquil", "cyndaquil.png", "Fire", 2 },
                    { 3, "Beldum (Japanese: ダンバル Dumbber) is a dual-type Steel/Psychic Pokémon introduced in Generation III. It evolves into Metang starting at level 20, which evolves into Metagross starting at level 45.", "Metang -> Metagross", "Beldum", "beldum.png", "Steel/Psychic", 3 },
                    { 4, "Gible (Japanese: フカマル Fukamaru) is a dual-type Dragon/Ground Pokémon introduced in Generation IV. It evolves into Gabite starting at level 24, which evolves into Garchomp starting at level 48.", "Gabite -> Garchomp", "Gible", "gible.png", "Dragon/Ground", 4 },
                    { 5, "Sandile (Japanese: メグロコ Meguroco) is a dual-type Ground/Dark Pokémon introduced in Generation V. It evolves into Krokorok starting at level 29, which evolves into Krookodile starting at level 40.", "Krokorok -> Krookodile", "Sandile", "sandile.png", "Ground/Dark", 5 },
                    { 6, "Fletchling (Japanese: ヤヤコマ Yayakoma) is a dual-type Normal/Flying Pokémon introduced in Generation VI. It evolves into Fletchinder starting at level 17, which evolves into Talonflame starting at level 35.", "Fletchinder -> Talonflame", "Fletchling", "fletchling.png", "Normal/Flying", 6 },
                    { 7, "Fomantis (Japanese: カリキリ Karikiri) is a Grass-type Pokémon introduced in Generation VII. It evolves into Lurantis when leveled up in the day starting at level 34.", "Lurantis", "Fomantis", "fomantis.png", "Grass", 7 },
                    { 9, "Meltan (Japanese: メルタン Meltan) is a Steel-type Mythical Pokémon introduced in Generation VII in Pokémon: Let's Go, Pikachu! and Let's Go, Eevee!. In Pokémon GO, it evolves into Melmetal by using 400 Meltan Candy. It cannot be evolved in other games. Its appearance was first teased during the September Pokémon GO Community Day on September 22, 2018, and it was officially revealed on September 25, 2018.", "Melmetal", "Meltan", "meltan.png", "Steel", 0 }
                });

            migrationBuilder.InsertData(
                table: "PokemonAttack",
                columns: new[] { "AttacksAttackId", "PokemonPokemonId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 25, 5 },
                    { 26, 6 },
                    { 27, 6 },
                    { 28, 6 },
                    { 29, 6 },
                    { 30, 6 },
                    { 31, 7 },
                    { 32, 7 },
                    { 33, 7 },
                    { 34, 7 },
                    { 35, 7 },
                    { 36, 8 },
                    { 37, 8 },
                    { 38, 8 },
                    { 39, 8 },
                    { 40, 8 },
                    { 41, 9 },
                    { 42, 9 },
                    { 43, 9 },
                    { 24, 5 },
                    { 44, 9 },
                    { 23, 5 },
                    { 21, 5 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 3 },
                    { 12, 3 },
                    { 13, 3 },
                    { 14, 3 },
                    { 15, 3 },
                    { 16, 4 },
                    { 17, 4 },
                    { 18, 4 },
                    { 19, 4 }
                });

            migrationBuilder.InsertData(
                table: "PokemonAttack",
                columns: new[] { "AttacksAttackId", "PokemonPokemonId" },
                values: new object[] { 20, 4 });

            migrationBuilder.InsertData(
                table: "PokemonAttack",
                columns: new[] { "AttacksAttackId", "PokemonPokemonId" },
                values: new object[] { 22, 5 });

            migrationBuilder.InsertData(
                table: "PokemonAttack",
                columns: new[] { "AttacksAttackId", "PokemonPokemonId" },
                values: new object[] { 45, 9 });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonAttack_AttacksAttackId",
                table: "PokemonAttack",
                column: "AttacksAttackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonAttack");

            migrationBuilder.DropTable(
                name: "Attacks");

            migrationBuilder.DropTable(
                name: "Pokemon");
        }
    }
}

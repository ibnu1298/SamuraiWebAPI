using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamuraiWebAPI.Data.Migrations
{
    public partial class addUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Battles",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Battles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Demons",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Level = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Demons", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Elements",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Elements", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Samurais",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Samurais", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "BattleDemon",
            //    columns: table => new
            //    {
            //        BattlesId = table.Column<int>(type: "int", nullable: false),
            //        DemonsId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BattleDemon", x => new { x.BattlesId, x.DemonsId });
            //        table.ForeignKey(
            //            name: "FK_BattleDemon_Battles_BattlesId",
            //            column: x => x.BattlesId,
            //            principalTable: "Battles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_BattleDemon_Demons_DemonsId",
            //            column: x => x.DemonsId,
            //            principalTable: "Demons",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DemonElement",
            //    columns: table => new
            //    {
            //        DemonsId = table.Column<int>(type: "int", nullable: false),
            //        ElementsId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DemonElement", x => new { x.DemonsId, x.ElementsId });
            //        table.ForeignKey(
            //            name: "FK_DemonElement_Demons_DemonsId",
            //            column: x => x.DemonsId,
            //            principalTable: "Demons",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_DemonElement_Elements_ElementsId",
            //            column: x => x.ElementsId,
            //            principalTable: "Elements",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BattleSamurai",
            //    columns: table => new
            //    {
            //        BattlesId = table.Column<int>(type: "int", nullable: false),
            //        SamuraisId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BattleSamurai", x => new { x.BattlesId, x.SamuraisId });
            //        table.ForeignKey(
            //            name: "FK_BattleSamurai_Battles_BattlesId",
            //            column: x => x.BattlesId,
            //            principalTable: "Battles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_BattleSamurai_Samurais_SamuraisId",
            //            column: x => x.SamuraisId,
            //            principalTable: "Samurais",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Swords",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        SamuraiId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Swords", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Swords_Samurais_SamuraiId",
            //            column: x => x.SamuraiId,
            //            principalTable: "Samurais",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ElementSwords",
            //    columns: table => new
            //    {
            //        SwordsId = table.Column<int>(type: "int", nullable: false),
            //        ElementsId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ElementSwords", x => new { x.ElementsId, x.SwordsId });
            //        table.ForeignKey(
            //            name: "FK_ElementSwords_Elements_ElementsId",
            //            column: x => x.ElementsId,
            //            principalTable: "Elements",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ElementSwords_Swords_SwordsId",
            //            column: x => x.SwordsId,
            //            principalTable: "Swords",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TypeSwords",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        SwordId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TypeSwords", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_TypeSwords_Swords_SwordId",
            //            column: x => x.SwordId,
            //            principalTable: "Swords",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_BattleDemon_DemonsId",
            //    table: "BattleDemon",
            //    column: "DemonsId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BattleSamurai_SamuraisId",
            //    table: "BattleSamurai",
            //    column: "SamuraisId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DemonElement_ElementsId",
            //    table: "DemonElement",
            //    column: "ElementsId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ElementSwords_SwordsId",
            //    table: "ElementSwords",
            //    column: "SwordsId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Swords_SamuraiId",
            //    table: "Swords",
            //    column: "SamuraiId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TypeSwords_SwordId",
            //    table: "TypeSwords",
            //    column: "SwordId",
            //    unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "BattleDemon");

            //migrationBuilder.DropTable(
            //    name: "BattleSamurai");

            //migrationBuilder.DropTable(
            //    name: "DemonElement");

            //migrationBuilder.DropTable(
            //    name: "ElementSwords");

            //migrationBuilder.DropTable(
            //    name: "TypeSwords");

            migrationBuilder.DropTable(
                name: "Users");

            //migrationBuilder.DropTable(
            //    name: "Battles");

            //migrationBuilder.DropTable(
            //    name: "Demons");

            //migrationBuilder.DropTable(
            //    name: "Elements");

            //migrationBuilder.DropTable(
            //    name: "Swords");

            //migrationBuilder.DropTable(
            //    name: "Samurais");
        }
    }
}

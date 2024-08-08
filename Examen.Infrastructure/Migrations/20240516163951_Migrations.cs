using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "activites",
                columns: table => new
                {
                    ActiviteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zone_Ville = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Zone_Pays = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    TypeService = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activites", x => x.ActiviteId);
                });

            migrationBuilder.CreateTable(
                name: "conseillers",
                columns: table => new
                {
                    ConseillerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conseillers", x => x.ConseillerId);
                });

            migrationBuilder.CreateTable(
                name: "packs",
                columns: table => new
                {
                    PackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NbPlaces = table.Column<int>(type: "int", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    IntitulePack = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ActiviteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packs", x => x.PackId);
                    table.ForeignKey(
                        name: "FK_packs_activites_ActiviteId",
                        column: x => x.ActiviteId,
                        principalTable: "activites",
                        principalColumn: "ActiviteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Identifiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ConseillerFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Identifiant);
                    table.ForeignKey(
                        name: "FK_clients_conseillers_ConseillerFk",
                        column: x => x.ConseillerFk,
                        principalTable: "conseillers",
                        principalColumn: "ConseillerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    DateReservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientFk = table.Column<int>(type: "int", nullable: false),
                    PackFk = table.Column<int>(type: "int", nullable: false),
                    NbPersonnes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => new { x.ClientFk, x.PackFk, x.DateReservation });
                    table.ForeignKey(
                        name: "FK_reservations_clients_ClientFk",
                        column: x => x.ClientFk,
                        principalTable: "clients",
                        principalColumn: "Identifiant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_packs_PackFk",
                        column: x => x.PackFk,
                        principalTable: "packs",
                        principalColumn: "PackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clients_ConseillerFk",
                table: "clients",
                column: "ConseillerFk");

            migrationBuilder.CreateIndex(
                name: "IX_packs_ActiviteId",
                table: "packs",
                column: "ActiviteId");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_PackFk",
                table: "reservations",
                column: "PackFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "packs");

            migrationBuilder.DropTable(
                name: "conseillers");

            migrationBuilder.DropTable(
                name: "activites");
        }
    }
}

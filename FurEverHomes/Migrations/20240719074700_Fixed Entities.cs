using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurEverHomes.Migrations
{
    /// <inheritdoc />
    public partial class FixedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adopters",
                columns: table => new
                {
                    AdopterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdopterFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdopterLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdopterEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdopterPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdopterAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adopters", x => x.AdopterId);
                });

            migrationBuilder.CreateTable(
                name: "Shelter",
                columns: table => new
                {
                    ShelterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShelterEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShelterPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShelterAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelter", x => x.ShelterId);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    PetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetSpecies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetBreed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetHealthStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetAge = table.Column<int>(type: "int", nullable: false),
                    AdopterId = table.Column<int>(type: "int", nullable: true),
                    ShelterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.PetId);
                    table.ForeignKey(
                        name: "FK_Pets_Adopters_AdopterId",
                        column: x => x.AdopterId,
                        principalTable: "Adopters",
                        principalColumn: "AdopterId");
                    table.ForeignKey(
                        name: "FK_Pets_Shelter_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelter",
                        principalColumn: "ShelterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdopterId = table.Column<int>(type: "int", nullable: false),
                    ShelterId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Application_Adopters_AdopterId",
                        column: x => x.AdopterId,
                        principalTable: "Adopters",
                        principalColumn: "AdopterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "PetId");
                    table.ForeignKey(
                        name: "FK_Application_Shelter_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelter",
                        principalColumn: "ShelterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_AdopterId",
                table: "Application",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_PetId",
                table: "Application",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_ShelterId",
                table: "Application",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_AdopterId",
                table: "Pets",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ShelterId",
                table: "Pets",
                column: "ShelterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Adopters");

            migrationBuilder.DropTable(
                name: "Shelter");
        }
    }
}

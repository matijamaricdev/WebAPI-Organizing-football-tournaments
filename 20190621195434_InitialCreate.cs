using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZavrsniRad.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Države",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Države", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Natjecanje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Datum_odigravanja = table.Column<DateTime>(nullable: false),
                    Ukupno_timova = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Natjecanje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timovi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: false),
                    Broj_igraca = table.Column<int>(nullable: false),
                    Kotizacija = table.Column<bool>(nullable: false),
                    Godine_igranja = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timovi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Županije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    DržavaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Županije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Županije_Države_DržavaId",
                        column: x => x.DržavaId,
                        principalTable: "Države",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Igrači",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    TimId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igrači", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Igrači_Timovi_TimId",
                        column: x => x.TimId,
                        principalTable: "Timovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Općine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: false),
                    ŽupanijaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Općine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Općine_Županije_ŽupanijaId",
                        column: x => x.ŽupanijaId,
                        principalTable: "Županije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nagrade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: false),
                    IgračId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nagrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nagrade_Igrači_IgračId",
                        column: x => x.IgračId,
                        principalTable: "Igrači",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Igrači_TimId",
                table: "Igrači",
                column: "TimId");

            migrationBuilder.CreateIndex(
                name: "IX_Nagrade_IgračId",
                table: "Nagrade",
                column: "IgračId");

            migrationBuilder.CreateIndex(
                name: "IX_Općine_ŽupanijaId",
                table: "Općine",
                column: "ŽupanijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Županije_DržavaId",
                table: "Županije",
                column: "DržavaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nagrade");

            migrationBuilder.DropTable(
                name: "Natjecanje");

            migrationBuilder.DropTable(
                name: "Općine");

            migrationBuilder.DropTable(
                name: "Igrači");

            migrationBuilder.DropTable(
                name: "Županije");

            migrationBuilder.DropTable(
                name: "Timovi");

            migrationBuilder.DropTable(
                name: "Države");
        }
    }
}

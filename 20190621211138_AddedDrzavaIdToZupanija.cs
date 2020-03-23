using Microsoft.EntityFrameworkCore.Migrations;

namespace ZavrsniRad.Migrations
{
    public partial class AddedDrzavaIdToZupanija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Županije_Države_DržavaId",
                table: "Županije");

            migrationBuilder.AlterColumn<int>(
                name: "DržavaId",
                table: "Županije",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Županije_Države_DržavaId",
                table: "Županije",
                column: "DržavaId",
                principalTable: "Države",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Županije_Države_DržavaId",
                table: "Županije");

            migrationBuilder.AlterColumn<int>(
                name: "DržavaId",
                table: "Županije",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Županije_Države_DržavaId",
                table: "Županije",
                column: "DržavaId",
                principalTable: "Države",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

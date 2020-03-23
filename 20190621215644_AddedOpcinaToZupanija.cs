using Microsoft.EntityFrameworkCore.Migrations;

namespace ZavrsniRad.Migrations
{
    public partial class AddedOpcinaToZupanija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Općine_Županije_ŽupanijaId",
                table: "Općine");

            migrationBuilder.AlterColumn<int>(
                name: "ŽupanijaId",
                table: "Općine",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Općine_Županije_ŽupanijaId",
                table: "Općine",
                column: "ŽupanijaId",
                principalTable: "Županije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Općine_Županije_ŽupanijaId",
                table: "Općine");

            migrationBuilder.AlterColumn<int>(
                name: "ŽupanijaId",
                table: "Općine",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Općine_Županije_ŽupanijaId",
                table: "Općine",
                column: "ŽupanijaId",
                principalTable: "Županije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

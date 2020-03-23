using Microsoft.EntityFrameworkCore.Migrations;

namespace ZavrsniRad.Migrations
{
    public partial class AddedIgraciToTim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Igrači_Timovi_TimId",
                table: "Igrači");

            migrationBuilder.AlterColumn<int>(
                name: "TimId",
                table: "Igrači",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Igrači_Timovi_TimId",
                table: "Igrači",
                column: "TimId",
                principalTable: "Timovi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Igrači_Timovi_TimId",
                table: "Igrači");

            migrationBuilder.AlterColumn<int>(
                name: "TimId",
                table: "Igrači",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Igrači_Timovi_TimId",
                table: "Igrači",
                column: "TimId",
                principalTable: "Timovi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

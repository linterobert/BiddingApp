using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiddingApp.API.Migrations
{
    public partial class nullKeyProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ClientProfiles_ClientProfileId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ClientProfileId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ClientProfiles_ClientProfileId",
                table: "Products",
                column: "ClientProfileId",
                principalTable: "ClientProfiles",
                principalColumn: "ClientProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ClientProfiles_ClientProfileId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ClientProfileId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ClientProfiles_ClientProfileId",
                table: "Products",
                column: "ClientProfileId",
                principalTable: "ClientProfiles",
                principalColumn: "ClientProfileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

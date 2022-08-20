using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiddingApp.Infrastructure.Migrations
{
    public partial class Configurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Products_ProductId",
                table: "ProductImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ClientProfiles_ClientId",
                table: "Reviews");

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
                name: "FK_ProductImage_Products_ProductId",
                table: "ProductImage",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ClientProfiles_ClientId",
                table: "Reviews",
                column: "ClientId",
                principalTable: "ClientProfiles",
                principalColumn: "ClientProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Products_ProductId",
                table: "ProductImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ClientProfiles_ClientId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "ClientProfileId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_Products_ProductId",
                table: "ProductImage",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ClientProfiles_ClientId",
                table: "Reviews",
                column: "ClientId",
                principalTable: "ClientProfiles",
                principalColumn: "ClientProfileId");
        }
    }
}

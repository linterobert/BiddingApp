using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiddingApp.API.Migrations
{
    public partial class removeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CompanyProfiles_CompanyProfileId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CompanyProfileId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CompanyProfileId1",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileId1",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyProfileId1",
                table: "Products",
                column: "CompanyProfileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CompanyProfiles_CompanyProfileId1",
                table: "Products",
                column: "CompanyProfileId1",
                principalTable: "CompanyProfiles",
                principalColumn: "CompanyProfileId");
        }
    }
}

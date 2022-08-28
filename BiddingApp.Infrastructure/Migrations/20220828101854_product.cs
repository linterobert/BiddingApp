using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiddingApp.Infrastructure.Migrations
{
    public partial class product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientNotification_ClientProfiles_ClientId",
                table: "ClientNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyNotification_CompanyProfiles_CompanyId",
                table: "CompanyNotification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyNotification",
                table: "CompanyNotification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientNotification",
                table: "ClientNotification");

            migrationBuilder.RenameTable(
                name: "CompanyNotification",
                newName: "CompanyNotifications");

            migrationBuilder.RenameTable(
                name: "ClientNotification",
                newName: "ClientNotifications");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyNotification_CompanyId",
                table: "CompanyNotifications",
                newName: "IX_CompanyNotifications_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientNotification_ClientId",
                table: "ClientNotifications",
                newName: "IX_ClientNotifications_ClientId");

            migrationBuilder.AlterColumn<int>(
                name: "ClientProfileId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyNotifications",
                table: "CompanyNotifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientNotifications",
                table: "ClientNotifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientNotifications_ClientProfiles_ClientId",
                table: "ClientNotifications",
                column: "ClientId",
                principalTable: "ClientProfiles",
                principalColumn: "ClientProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyNotifications_CompanyProfiles_CompanyId",
                table: "CompanyNotifications",
                column: "CompanyId",
                principalTable: "CompanyProfiles",
                principalColumn: "CompanyProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientNotifications_ClientProfiles_ClientId",
                table: "ClientNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyNotifications_CompanyProfiles_CompanyId",
                table: "CompanyNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyNotifications",
                table: "CompanyNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientNotifications",
                table: "ClientNotifications");

            migrationBuilder.RenameTable(
                name: "CompanyNotifications",
                newName: "CompanyNotification");

            migrationBuilder.RenameTable(
                name: "ClientNotifications",
                newName: "ClientNotification");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyNotifications_CompanyId",
                table: "CompanyNotification",
                newName: "IX_CompanyNotification_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientNotifications_ClientId",
                table: "ClientNotification",
                newName: "IX_ClientNotification_ClientId");

            migrationBuilder.AlterColumn<int>(
                name: "ClientProfileId",
                table: "Products",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyNotification",
                table: "CompanyNotification",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientNotification",
                table: "ClientNotification",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientNotification_ClientProfiles_ClientId",
                table: "ClientNotification",
                column: "ClientId",
                principalTable: "ClientProfiles",
                principalColumn: "ClientProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyNotification_CompanyProfiles_CompanyId",
                table: "CompanyNotification",
                column: "CompanyId",
                principalTable: "CompanyProfiles",
                principalColumn: "CompanyProfileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

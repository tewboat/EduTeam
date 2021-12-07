using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    public partial class ManyToManyRelationshipFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InvitationProject_UserGuid1",
                table: "UserProject",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserGuid1",
                table: "UserProject",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_InvitationProject_UserGuid1",
                table: "UserProject",
                column: "InvitationProject_UserGuid1");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_UserGuid1",
                table: "UserProject",
                column: "UserGuid1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProject_Users_InvitationProject_UserGuid1",
                table: "UserProject",
                column: "InvitationProject_UserGuid1",
                principalTable: "Users",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProject_Users_UserGuid1",
                table: "UserProject",
                column: "UserGuid1",
                principalTable: "Users",
                principalColumn: "Guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProject_Users_InvitationProject_UserGuid1",
                table: "UserProject");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProject_Users_UserGuid1",
                table: "UserProject");

            migrationBuilder.DropIndex(
                name: "IX_UserProject_InvitationProject_UserGuid1",
                table: "UserProject");

            migrationBuilder.DropIndex(
                name: "IX_UserProject_UserGuid1",
                table: "UserProject");

            migrationBuilder.DropColumn(
                name: "InvitationProject_UserGuid1",
                table: "UserProject");

            migrationBuilder.DropColumn(
                name: "UserGuid1",
                table: "UserProject");
        }
    }
}

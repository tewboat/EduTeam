using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    public partial class ManyToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProject_Projects_ProjectGuid2",
                table: "UserProject");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProject_Projects_ProjectGuid3",
                table: "UserProject");

            migrationBuilder.DropIndex(
                name: "IX_UserProject_ProjectGuid2",
                table: "UserProject");

            migrationBuilder.DropIndex(
                name: "IX_UserProject_ProjectGuid3",
                table: "UserProject");

            migrationBuilder.DropColumn(
                name: "ProjectGuid2",
                table: "UserProject");

            migrationBuilder.DropColumn(
                name: "ProjectGuid3",
                table: "UserProject");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "UserProject",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "UserProject");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectGuid2",
                table: "UserProject",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectGuid3",
                table: "UserProject",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_ProjectGuid2",
                table: "UserProject",
                column: "ProjectGuid2");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_ProjectGuid3",
                table: "UserProject",
                column: "ProjectGuid3");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProject_Projects_ProjectGuid2",
                table: "UserProject",
                column: "ProjectGuid2",
                principalTable: "Projects",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProject_Projects_ProjectGuid3",
                table: "UserProject",
                column: "ProjectGuid3",
                principalTable: "Projects",
                principalColumn: "Guid");
        }
    }
}

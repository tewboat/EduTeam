using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    public partial class TeamRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleProject_TeamRole_TeamRoleGuid",
                table: "RoleProject");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "TeamRole");

            migrationBuilder.CreateTable(
                name: "TeamRoles",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserGuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamRoles", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_TeamRoles_Users_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TeamRoles_UserGuid",
                table: "TeamRoles",
                column: "UserGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleProject_TeamRoles_TeamRoleGuid",
                table: "RoleProject",
                column: "TeamRoleGuid",
                principalTable: "TeamRoles",
                principalColumn: "Guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleProject_TeamRoles_TeamRoleGuid",
                table: "RoleProject");

            migrationBuilder.DropTable(
                name: "TeamRoles");

            migrationBuilder.CreateTable(
                name: "TeamRole",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamRole", x => x.Guid);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserGuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleGuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TeamRoleGuid = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserGuid, x.RoleGuid });
                    table.ForeignKey(
                        name: "FK_UserRole_TeamRole_TeamRoleGuid",
                        column: x => x.TeamRoleGuid,
                        principalTable: "TeamRole",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_TeamRoleGuid",
                table: "UserRole",
                column: "TeamRoleGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleProject_TeamRole_TeamRoleGuid",
                table: "RoleProject",
                column: "TeamRoleGuid",
                principalTable: "TeamRole",
                principalColumn: "Guid");
        }
    }
}
